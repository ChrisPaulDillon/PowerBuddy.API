using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.ExternalLoginProviderService.Configuration
{
    public static class ExternalLoginProviderConfiguration
    {
        public static void AddFacebookAuthServices(this IServiceCollection services, string facebookAppId, string facebookSecret)
        {
            services.AddSingleton<IFacebookConfig>(serviceProvider => new FacebookConfig(facebookAppId, facebookSecret));
            services.AddScoped<IFacebookAuthService, FacebookAuthService>();
        }
    }
}