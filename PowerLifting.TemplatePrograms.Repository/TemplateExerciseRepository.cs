using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateExerciseRepository : RepositoryBase<TemplateExercise>, ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
