using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.API.AuthorizationHandlers;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Middleware;
using PowerBuddy.Data.AutoMapper;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Extensions;
using PowerBuddy.EmailService.Extensions;
using PowerBuddy.MediatR.Extensions;
using PowerBuddy.Services;
using PowerBuddy.SmsService.Extensions;

namespace PowerBuddy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSmsServices(
                Configuration.GetValue<string>("TwilioAccountSID"),
                Configuration.GetValue<string>("TwilioAuthToken"), 
                Configuration.GetValue<string>("TwilioVerificationServiceSID")
                );

            services.AddMediatrHandlers(Configuration.GetValue<string>("EmailBaseUrl"), Configuration.GetValue<string>("EmailSiteName"));

            services.AddEmailServices
                (Configuration.GetValue<string>("SMTPHost"), 
                Configuration.GetValue<int>("SMTPPort"), 
                Configuration.GetValue<string>("SMTPUsername"), 
                Configuration.GetValue<string>("SMTPPassword"));

            services.AddFactories();
            services.AddServiceClasses();

            //Inject app settings
            services.AddJWTSettings(Configuration.GetSection("JWT_Config"));
            services.AddSentry(Configuration.GetSection("Sentry"));
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(Configuration.GetSection("PbDbConnection").Value));


            services.AddDefaultIdentity<User>(options =>
	            {
		            options.SignIn.RequireConfirmedAccount = true;
		            options.Lockout.MaxFailedAccessAttempts = 10;
		            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
	            })
                .AddEntityFrameworkStores<PowerLiftingContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
	            options.Lockout.MaxFailedAccessAttempts = 10;
	            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(Configuration["CorsPolicyClientUrl"])
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .WithMethods("GET", "PUT", "POST", "DELETE");
                    });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SystemAutoMapperProfile());
                mc.AddProfile(new LiftingStatMappingProfile());
                mc.AddProfile(new ProgramLogMappingProfile());
                mc.AddProfile(new TemplateProgramMappingProfile());
                mc.AddProfile(new AccountMappingProfile());
                mc.AddProfile(new WorkoutMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerBuddy.API", Version = "v1" });
            });

            services.AddTransient<IAuthorizationHandler, IsModeratorAuthorizationHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsModerator",
                    policy => policy.Requirements.Add(new IsModeratorValidationRequirement()));
            });
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

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
