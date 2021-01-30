using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Emails.Commands;
using PowerBuddy.MediatR.Emails.Models;

namespace PowerBuddy.MediatR.Emails
{
    public static class EmailServicesConfiguration
    {
        public static IServiceCollection AddEmailMediatrHandlers(this IServiceCollection services, string baseUrl, string siteName)
        {
            services.AddSingleton<IEmailAssistant>(serviceProvider => new EmailAssistant(baseUrl, siteName));

            // CommandHandler Registration
            services.AddMediatR(typeof(SendConfirmEmailCommandHandler));
            services.AddMediatR(typeof(SendPasswordResetCommandHandler));

            // QueryHandler Registration
            return services;
        }
    }
}
