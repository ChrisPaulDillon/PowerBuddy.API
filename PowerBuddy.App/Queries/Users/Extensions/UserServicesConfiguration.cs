using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Queries.Authentication;

namespace PowerBuddy.App.Queries.Users.Extensions
{
    public static class UserServicesConfiguration
    {
        public static IServiceCollection AddUserMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllUsersByAdminQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByIdQueryHandler));
            services.AddMediatR(typeof(GetPublicUserProfileByUsernameQueryHandler));
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(GetUserProfileQueryHandler));


            return services;
        }
    }
}