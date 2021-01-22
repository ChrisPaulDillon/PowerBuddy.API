using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.AuthenticationService.Configuration
{
    public static class ExternalLoginProviderConfiguration
    {
        public static void AddAuthServices(this IServiceCollection services, string jwtKey, string jwtIssuer, string facebookAppId, string facebookSecret)
        {
            services.AddSingleton<IJwtConfig>(serviceProvider => new JwtConfig(jwtKey, jwtIssuer));
            services.AddFacebookAuthServices(facebookAppId, facebookSecret);
        }

        internal static void AddFacebookAuthServices(this IServiceCollection services, string facebookAppId, string facebookSecret)
        {
            services.AddSingleton<IFacebookConfig>(serviceProvider => new FacebookConfig(facebookAppId, facebookSecret));
            services.AddScoped<IFacebookAuthService, FacebookAuthService>();
        }
    }
}