using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.EmailService.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddEmailServices(this IServiceCollection services, string host, int port, string userName, string password)
        {
            services.AddSingleton<IEmailConfig>(serviceProvider => new EmailConfig(host, port, userName, password));
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
