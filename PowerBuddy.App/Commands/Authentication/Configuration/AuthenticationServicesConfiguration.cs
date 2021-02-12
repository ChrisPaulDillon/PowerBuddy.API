using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.Sms;

namespace PowerBuddy.App.Commands.Authentication.Configuration
{
    public static class AuthenticationServicesConfiguration
    {
        public static IServiceCollection AddAuthenticationMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(RegisterUserCommandHandler));
            services.AddMediatR(typeof(ResetPasswordViaEmailCommandHandler));
            services.AddMediatR(typeof(AcceptEmailConfirmationCommandHandler));
            services.AddMediatR(typeof(UpdatePasswordCommandHandler));
            services.AddMediatR(typeof(SendSmsVerificationCommandHandler));
            services.AddMediatR(typeof(AcceptSmsVerificationCommandHandler));
            services.AddMediatR(typeof(RefreshTokenCommandHandler));
            services.AddMediatR(typeof(LogoutCommandHandler));

            return services;
        }
    }
}
