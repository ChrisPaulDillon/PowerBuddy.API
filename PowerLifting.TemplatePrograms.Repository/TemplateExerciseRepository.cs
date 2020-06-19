using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateExerciseRepository : ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerliftingContext context, IMapper mapper)
        {
        }
    }
}
