using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Quotes;

namespace PowerBuddy.MediatR.Queries.TemplatePrograms.Extensions
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
