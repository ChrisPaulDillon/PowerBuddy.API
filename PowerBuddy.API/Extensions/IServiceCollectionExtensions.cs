using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Util;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;
using PowerBuddy.Services.System;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IDTOFactory, DTOFactory>();
            return services;
        }

        public static IServiceCollection AddServiceClasses(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILiftingStatService, LiftingStatService>();
            services.AddScoped<IProgramLogService, ProgramLogService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IWorkoutService, WorkoutService>();

            return services;
        }


        public static IServiceCollection AddPowerLiftingContext(this IServiceCollection services, string connectionStr)
        {
            services.AddDbContext<PowerLiftingContext>(options =>
                options.UseSqlServer(connectionStr));

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfigurationSection corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")//corsConfig["Client_URL"].ToString(), "")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            return services;
        }

        public static IServiceCollection AddSentry(this IServiceCollection services, IConfigurationSection sentryConfig)
        {
            //TODO
            //services.Configure<ApplicationSettings>(applicationSettings));
            return services;
        }

        public static IServiceCollection AddJWTSettings(this IServiceCollection services, IConfigurationSection jwtSettings)
        {
            services.Configure<JWTSettings>(jwtSettings);
            services.AddSingleton(svc => svc.GetService<IOptions<JWTSettings>>().Value);
            var key = Encoding.UTF8.GetBytes(jwtSettings["JWT_Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
