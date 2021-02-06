using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.App.Commands.WorkoutDays;
using PowerBuddy.App.Commands.WorkoutExercises;
using PowerBuddy.App.Commands.WorkoutSets;
using PowerBuddy.App.Commands.WorkoutTemplates;

namespace PowerBuddy.App.Commands.Workouts
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
            services.AddMediatR(typeof(UpdateWorkoutDayNotesCommandHandler));
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
