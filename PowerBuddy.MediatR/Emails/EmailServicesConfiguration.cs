using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Emails.Commands;

namespace PowerBuddy.MediatR.Emails
{
    internal static class EmailServicesConfiguration
    {
        internal static IServiceCollection AddEmailMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(ConfirmEmailCommandHandler));
            services.AddMediatR(typeof(SendPasswordResetCommandHandler));

            // QueryHandler Registration
            return services;
        }

    }
}
