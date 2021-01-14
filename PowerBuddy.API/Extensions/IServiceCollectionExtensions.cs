using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.Data.Util;

namespace PowerBuddy.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
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
