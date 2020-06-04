using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
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
