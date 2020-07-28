using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Repository.Contracts;

namespace PowerLifting.TemplatePrograms.Repository.Concrete
{
    public class TemplateExerciseRepository : ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerLiftingContext context, IMapper mapper)
        {
        }
    }
}
