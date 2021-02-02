using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Commands.Emails;
using PowerBuddy.MediatR.Commands.LiftingStats;
using PowerBuddy.MediatR.Commands.Quotes;
using PowerBuddy.MediatR.Commands.TemplatePrograms;
using PowerBuddy.MediatR.Commands.Users;
using PowerBuddy.MediatR.Commands.Workouts;
using PowerBuddy.MediatR.Commands.WorkoutTemplates.Configuration;

namespace PowerBuddy.MediatR.Commands
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
            services.AddAuthentication();

            services.AddEmailMediatrHandlers(baseUrl, siteName);

            return services;
        }

        private static IServiceCollection AddTemplateProgramMediatrHandlers(this IServiceCollection services)
        {
            // CommandHandler Registration
            services.AddMediatR(typeof(CreateTemplateProgramCommandHandler));
            services.AddMediatR(typeof(CreateTemplateExerciseCollectionForTemplateCommandHandler));

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
