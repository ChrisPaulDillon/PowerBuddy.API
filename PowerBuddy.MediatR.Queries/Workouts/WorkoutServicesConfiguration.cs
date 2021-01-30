using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.WorkoutDays;
using PowerBuddy.Services.Workouts.Factories;
using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.MediatR.Queries.Workouts
{
    public static class WorkoutServicesConfiguration
    {
        public static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {

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
