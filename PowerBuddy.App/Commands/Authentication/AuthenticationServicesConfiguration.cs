using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.App.Commands.Authentication
{
    public static class AuthenticationServicesConfiguration
    {
        public static IServiceCollection AddAuthenticationMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(RegisterUserCommandHandler));
            services.AddMediatR(typeof(ResetPasswordCommandHandler));
            services.AddMediatR(typeof(VerifyEmailCommandHandler));
            services.AddMediatR(typeof(UpdatePasswordCommandHandler));
            services.AddMediatR(typeof(RequestSmsVerificationCommandHandler));
            services.AddMediatR(typeof(SendSmsVerificationCommandHandler));
            services.AddMediatR(typeof(RefreshTokenCommandHandler));
            services.AddMediatR(typeof(LogoutCommandHandler));

            return services;
        }
    }
}
