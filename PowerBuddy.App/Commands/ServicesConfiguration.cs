using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.Authentication.Configuration;
using PowerBuddy.App.Commands.Emails;
using PowerBuddy.App.Commands.LiftingStats;
using PowerBuddy.App.Commands.Quotes;
using PowerBuddy.App.Commands.Sms.Configuration;
using PowerBuddy.App.Commands.TemplatePrograms;
using PowerBuddy.App.Commands.Users;
using PowerBuddy.App.Commands.Workouts;
using PowerBuddy.App.Commands.WorkoutTemplates.Configuration;

namespace PowerBuddy.App.Commands
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrCommandHandlers(this IServiceCollection services, string baseUrl, string siteName)
        {
            services.AddQuoteMediatrHandlers();
            services.AddWorkoutTemplateCommandHandlers();
            services.AddLiftingStatsMediatrHandlers();
            services.AddTemplateProgramMediatrHandlers();
            services.AddUserMediatrHandlers();
            services.AddWorkoutMediatrHandlers();
            services.AddAuthenticationMediatrHandlers();
            services.AddSmsMediatrHandlers();

            services.AddEmailMediatrHandlers(baseUrl, siteName);

            return services;
        }

        private static IServiceCollection AddTemplateProgramMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateTemplateProgramCommandHandler));

            return services;
        }

        private static IServiceCollection AddLiftingStatsMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(DeleteLiftingStatAuditCommandHandler));

            return services;
        }

        private static IServiceCollection AddQuoteMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(RequestQuoteCommandHandler));
            services.AddMediatR(typeof(CreateQuoteCommandHandler));
            services.AddMediatR(typeof(UpdateQuoteCommandHandler));
            services.AddMediatR(typeof(DeleteQuoteCommandHandler));

            return services;
        }
    }
}
