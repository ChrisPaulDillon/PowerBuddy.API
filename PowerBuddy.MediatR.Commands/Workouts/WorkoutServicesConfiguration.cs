using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Commands.WorkoutDays;
using PowerBuddy.MediatR.Commands.WorkoutExercises;
using PowerBuddy.MediatR.Commands.WorkoutSets;
using PowerBuddy.MediatR.Commands.WorkoutTemplates;
using PowerBuddy.Services.Workouts.Factories;
using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.MediatR.Commands.Workouts
{
    public static class WorkoutServicesConfiguration
    {
        public static IServiceCollection AddWorkoutMediatrHandlers(this IServiceCollection services)
        {
            // Workout Logs Query & Command Handlers
            services.AddMediatR(typeof(CreateWorkoutLogFromTemplateCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutTemplateCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutLogCommandHandler));

            // Workout Days
            services.AddMediatR(typeof(CompleteWorkoutCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutDayCommandHandler));

            // Workout Exercises
            services.AddMediatR(typeof(CreateWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(DeleteWorkoutExerciseCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutExerciseNotesCommandHandler));

            // Workout Sets
            services.AddMediatR(typeof(DeleteWorkoutSetCommandHandler));
            services.AddMediatR(typeof(QuickAddWorkoutSetsCommandHandler));
            services.AddMediatR(typeof(UpdateWorkoutSetCommandHandler));

            return services;
        }
    }
}
