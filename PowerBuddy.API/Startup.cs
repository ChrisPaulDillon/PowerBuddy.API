using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.API.AuthorizationHandlers;
using PowerBuddy.API.Extensions;
using PowerBuddy.App.Commands;
using PowerBuddy.App.Pipelines;
using PowerBuddy.App.Queries;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.App.Repositories.System;
using PowerBuddy.App.Services;
using PowerBuddy.AuthenticationService.Configuration;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Extensions;
using PowerBuddy.Data.Util;
using PowerBuddy.EmailService.Extensions;
using PowerBuddy.FileHandlerService.Services;
using PowerBuddy.SmsService.Extensions;
using PowerBuddy.SignalR;

namespace PowerBuddy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ImageFileHandlerService>();

	        services.AddMetrics();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .WithOrigins("https://localhost:3000", "http://localhost:3000", "https://webapp.powerbuddy.gg", "https://www.powerbuddy.gg")
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod());
            });

            services.AddSmsServices(
                Configuration.GetValue<string>("TwilioAccountSID"),
                Configuration.GetValue<string>("TwilioAuthToken"),
                Configuration.GetValue<string>("TwilioVerificationServiceSID")
            );

            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            }).AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblies(new List<Assembly>()
                {
                    Assembly.Load("PowerBuddy.App")
                });
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.Decorate<IExerciseRepository, CachedExerciseRepository>();

            services.AddScoped<ISystemRepository, SystemRepository>();
            services.Decorate<ISystemRepository, CachedSystemRepository>();


            services.AddMediatrQueryHandlers();
            services.AddMediatrCommandHandlers(Configuration.GetValue<string>("EmailBaseUrl"),
                Configuration.GetValue<string>("EmailSiteName"));

            services.AddEmailServices
            (Configuration.GetValue<string>("SMTPHost"),
                Configuration.GetValue<int>("SMTPPort"),
                Configuration.GetValue<string>("SMTPUsername"),
                Configuration.GetValue<string>("SMTPPassword"));

            services.AddFactories();
            services.AddServiceClasses();

            services.AddSingleton(new ContextConfig()
            {
                DbContextStr = Configuration.GetSection("PbDbConnection").Value
            });

            //Inject app settings
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(Configuration.GetSection("PbDbConnection").Value));

            services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;

                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                })
                .AddEntityFrameworkStores<PowerLiftingContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup).Assembly, Assembly.Load("PowerBuddy.Data"));

            services.AddSignalR();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerBuddy.API", Version = "v1" });
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
                options.AddPolicy("IsModerator",policy => policy.Requirements.Add(new IsModeratorValidationRequirement()));
                options.AddPolicy("IsValidUser",policy => policy.Requirements.Add(new IsValidUserValidationRequirement()));
            });

            services.AddAuthServices(
                Configuration.GetValue<string>("JWT_Key"),
                Configuration.GetValue<string>("JWT_Issuer"),
                Configuration.GetValue<TimeSpan>("JWT_Lifetime"),
                Configuration.GetValue<string>("FacebookAppId"), 
                Configuration.GetValue<string>("FacebookAppSecret"));

            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration.GetValue<string>("JWT_Issuer"),
                        ValidAudience = Configuration.GetValue<string>("JWT_Issuer"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWT_Key"))),
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                })
                .AddGoogle(opt =>
	            {
                    opt.ClientId = Configuration.GetValue<string>("GoogleClientId");
                    opt.ClientSecret = Configuration.GetValue<string>("GoogleClientSecret");
                })
	            .AddFacebook(opt =>
	            {
		            opt.AppId = Configuration.GetValue<string>("FacebookAppId");
		            opt.AppSecret = Configuration.GetValue<string>("FacebookAppSecret");
	            });

            services.AddTransient<IAuthorizationHandler, IsModeratorAuthorizationHandler>();
            services.AddTransient<IAuthorizationHandler, IsValidUserAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerBuddy.API v1"));
            }

            app.UseExceptionHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/message");
            });
        }
    }
}
