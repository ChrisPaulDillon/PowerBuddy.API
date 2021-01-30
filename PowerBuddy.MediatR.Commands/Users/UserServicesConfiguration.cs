using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Commands.Authentication;

namespace PowerBuddy.MediatR.Commands.Users
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
            services.AddMediatR(typeof(ResetPasswordCommandHandler));
            services.AddMediatR(typeof(VerifyEmailCommandHandler));
            services.AddMediatR(typeof(UpdatePasswordCommandHandler));
            services.AddMediatR(typeof(RequestSmsVerificationCommandHandler));
            services.AddMediatR(typeof(SendSmsVerificationCommandHandler));
            return services;
        }
    }
}