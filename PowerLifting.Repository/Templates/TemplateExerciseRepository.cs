using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateExerciseRepository : RepositoryBase<TemplateExercise>, ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
