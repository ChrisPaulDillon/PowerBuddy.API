using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Authentication.Commands;
using PowerBuddy.MediatR.Authentication.Querys;
using PowerBuddy.MediatR.Users.Commands;
using PowerBuddy.MediatR.Users.Querys;

namespace PowerBuddy.MediatR.Users
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