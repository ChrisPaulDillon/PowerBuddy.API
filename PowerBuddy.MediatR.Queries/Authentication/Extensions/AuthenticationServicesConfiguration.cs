using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.MediatR.Queries.Authentication
{
    public static class AuthenticationServicesConfiguration
    {
        public static IServiceCollection AddAuthenticationMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(LoginWithFacebookQueryHandler));

            return services;
        }
    }
}
