using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Queries.Authentication.Extensions;
using PowerBuddy.App.Queries.Exercises.Extensions;
using PowerBuddy.App.Queries.LiftingStats.Extensions;
using PowerBuddy.App.Queries.Metrics.Extensions;
using PowerBuddy.App.Queries.Quotes.Extensions;
using PowerBuddy.App.Queries.TemplatePrograms.Extensions;
using PowerBuddy.App.Queries.Users.Extensions;
using PowerBuddy.App.Queries.Workouts;

namespace PowerBuddy.App.Queries
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMediatrQueryHandlers(this IServiceCollection services)
        {
            services.AddAuthenticationMediatrHandlers();
            services.AddExerciseMediatrHandlers();
            services.AddMetricMediatrHandlers();
            services.AddQuoteMediatrHandlers();
            services.AddLiftingStatsMediatrHandlers();
            services.AddTemplateMediatrHandlers();
            services.AddUserMediatrHandlers();
            services.AddWorkoutMediatrHandlers();
            services.AddAuthentication();

            return services;
        }
    }
}
