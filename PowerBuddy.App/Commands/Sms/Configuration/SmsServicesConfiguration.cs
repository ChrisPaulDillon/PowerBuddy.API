using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.Authentication;

namespace PowerBuddy.App.Commands.Sms.Configuration
{
	public static class SmsServicesConfiguration
	{
		public static IServiceCollection AddSmsMediatrHandlers(this IServiceCollection services)
		{
			// CommandHandler Registration
			services.AddMediatR(typeof(AcceptSmsVerificationCommandHandler));

			return services;
		}
	}
}
