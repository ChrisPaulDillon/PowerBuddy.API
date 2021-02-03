using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.App.Queries.TemplatePrograms.Extensions
{
    public static class TemplateProgramServicesConfiguration
    {
        public static IServiceCollection AddTemplateMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllTemplateProgramsQueryHandler));
            services.AddMediatR(typeof(GetPersonalBestsForTemplateExercisesQueryHandler));
            services.AddMediatR(typeof(GetTecByTemplateProgramIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateActivityFeedQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramByIdQueryHandler));
            services.AddMediatR(typeof(GetTemplateProgramsBySearchQueryHandler));
            return services;
        }
    }
}
