using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Queries.WorkoutDays;

namespace PowerBuddy.App.Queries.Workouts
{
    public static class WorkoutServicesConfiguration
    {
        public static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {

            services.AddMediatR(typeof(GetWorkoutDayByIdQueryHandler));
            services.AddMediatR(typeof(GetWorkoutCalendarQueryHandler));
            services.AddMediatR(typeof(GetWorkoutWeekByDateQueryHandler));
            services.AddMediatR(typeof(GetAllWorkoutStatsQueryHandler));

            // Workout Days
            services.AddMediatR(typeof(GetWorkoutDayByIdQueryHandler));
            services.AddMediatR(typeof(GetWorkoutDayIdByDateQueryHandler));

            // Misc
            return services;
        }
    }
}
