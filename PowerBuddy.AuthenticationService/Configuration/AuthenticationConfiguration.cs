using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PowerBuddy.AuthenticationService.Configuration
{
    public static class ExternalLoginProviderConfiguration
    {
        public static void AddAuthServices(this IServiceCollection services, string jwtKey, string jwtIssuer, TimeSpan jwtLifetime, string facebookAppId, string facebookSecret)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddSingleton<IJwtConfig>(serviceProvider => new JwtConfig(jwtKey, jwtIssuer, jwtLifetime));
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpClient();

            services.AddFacebookAuthServices(facebookAppId, facebookSecret);
        }

        private static void AddFacebookAuthServices(this IServiceCollection services, string facebookAppId, string facebookSecret)
        {
            services.AddSingleton<IFacebookConfig>(serviceProvider => new FacebookConfig(facebookAppId, facebookSecret));
            services.AddScoped<IFacebookAuthService, FacebookAuthService>();
        }
    }
}