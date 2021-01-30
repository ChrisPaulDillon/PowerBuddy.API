using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.WorkoutDays.Commands;
using PowerBuddy.MediatR.WorkoutDays.Querys;
using PowerBuddy.MediatR.WorkoutExercises.Commands;
using PowerBuddy.MediatR.Workouts.Commands;
using PowerBuddy.MediatR.Workouts.Querys;
using PowerBuddy.MediatR.WorkoutSets.Commands;
using PowerBuddy.Services.Workouts.Factories;
using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.MediatR.Workouts
{
    public static class WorkoutServicesConfiguration
    {
        public static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {
            // Workout Logs Query & Command Handlers
            services.AddMediatR(typeof(CreateWorkoutLogFromTemplateCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutTemplateCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutLogCommandHandler));

            services.AddMediatR(typeof(GetWorkoutWeekByDateQueryHandler));
            services.AddMediatR(typeof(GetAllWorkoutStatsQueryHandler));

            // Workout Days
            services.AddMediatR(typeof(GetWorkoutDayByIdQueryHandler));
            services.AddMediatR(typeof(CompleteWorkoutCommandHandler));
            services.AddMediatR(typeof(GetWorkoutDayIdByDateQueryHandler));
            services.AddMediatR(typeof(CreateWorkoutDayCommandHandler));

            // Workout Exercises
            services.AddMediatR(typeof(CreateWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutExerciseNotesCommandHandler));

            // Workout Sets
            services.AddMediatR(typeof(DeleteWorkoutSetCommandHandler));
            services.AddMediatR(typeof(QuickAddWorkoutSetsCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutSetCommandHandler));

            // Misc
            services.AddScoped<ICalculateWeightFactory, CalculateWeightFactory>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightIncremental>();
            services.AddScoped<ICalculateRepWeight, CalculateRepWeightPercentage>();
            return services;
        }
    }
}
