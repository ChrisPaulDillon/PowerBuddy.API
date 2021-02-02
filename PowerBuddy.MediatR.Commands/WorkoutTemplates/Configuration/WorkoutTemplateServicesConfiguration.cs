using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.MediatR.Commands.WorkoutTemplates.Configuration
{
    public static class WorkoutTemplateServicesConfiguration
    {
        public static IServiceCollection AddWorkoutTemplateCommandHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DeleteWorkoutTemplateCommandHandler));
            services.AddMediatR(typeof(CreateWorkoutTemplateCommandHandler));

            return services;
        }
    }
}
