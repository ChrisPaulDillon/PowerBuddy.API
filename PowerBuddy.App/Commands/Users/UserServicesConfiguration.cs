using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.Authentication;

namespace PowerBuddy.App.Commands.Users
{
    public static class UserServicesConfiguration
    {
        public static IServiceCollection AddUserMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(BanUserCommandHandler));
            services.AddMediatR(typeof(RegisterUserCommandHandler));
            services.AddMediatR(typeof(CreateFirstVisitStatsCommandHandler));
            services.AddMediatR(typeof(EditProfileCommandHandler));
            return services;
        }
    }
}