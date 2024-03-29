﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.Emails.Models;

namespace PowerBuddy.App.Commands.Emails
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
