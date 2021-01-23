using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Authentication.Commands;
using PowerBuddy.MediatR.Authentication.Querys;
using PowerBuddy.MediatR.Users.Commands;
using PowerBuddy.MediatR.Users.Commands.PowerBuddy.MediatR.Users.Querys;
using PowerBuddy.MediatR.Users.Querys;

namespace PowerBuddy.MediatR.Authentication
{
    internal static class AuthenticationServicesConfiguration
    {
        internal static IServiceCollection AddAuthenticationMediatrHandlers(this IServiceCollection services)
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

            // QueryHandler Registration
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(LoginWithFacebookQueryHandler));

            return services;
        }
    }
}
