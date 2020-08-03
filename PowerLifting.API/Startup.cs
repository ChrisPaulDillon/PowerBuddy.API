using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using PowerLifting.LoggerService;
using Microsoft.AspNetCore.Http;
using PowerLifting.API.Wrappers;
using PowerLifting.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PowerLifting.API.Middleware;
using PowerLifting.Data;
using PowerLifting.Data.AutoMapper;
using PowerLifting.Data.Entities.Account;
using PowerLifting.SignalR;
using PowerLifting.Data.Util;
using PowerLifting.API.Extensions;

namespace PowerLifting.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //Inject app settings
            services.AddJWTSettings(Configuration.GetSection("JWT_Settings"));
            services.AddSentry(Configuration.GetSection("Sentry"));
            services.AddPowerLiftingContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddCorsPolicy(Configuration.GetSection("CorsPolicy"));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddDbContext<PowerliftingContext>(options =>
            //  options.UseSqlite("DataSource = app.db"));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PowerLiftingContext>();

            services.AddControllers();

            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new SystemAutoMapperProfile());
                 mc.AddProfile(new LiftingStatMappingProfile());
                 mc.AddProfile(new ProgramLogMappingProfile());
                 mc.AddProfile(new TemplateProgramMappingProfile());
                 mc.AddProfile(new AccountMappingProfile());
             });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerBuddy API", Version = "v1" });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //        builder =>
            //        {
            //            builder.WithOrigins("https://localhost:44329/",
            //                "https://localhost:5001/");
            //        });
            //});

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger);
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                 .AllowAnyHeader()
                 .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }
    }
}
