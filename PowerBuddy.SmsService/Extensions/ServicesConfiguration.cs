using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.SmsService.Models;
using Twilio;

namespace PowerBuddy.SmsService.Extensions
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddSmsServices(this IServiceCollection services, string twilioAccountSid, string twilioAuthToken, string twilioVerificationServiceSID)
        {
            services.AddSingleton<ITwilioSettings>(serviceProvider => new TwilioSettings(twilioVerificationServiceSID));
            services.AddScoped<ISmsClient, SmsClient>();

            TwilioClient.Init(twilioAccountSid, twilioAuthToken);

            return services;
        }

    }
}
