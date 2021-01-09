﻿using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.EmailService.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddEmailServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
