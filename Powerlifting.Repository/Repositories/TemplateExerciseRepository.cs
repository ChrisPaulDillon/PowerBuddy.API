using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplateExercises;
using Powerlifting.Service.TemplateExercises.Model;

namespace PowerLifting.Repository.Repositories
{
    public class TemplateExerciseRepository : RepositoryBase<TemplateExercise>, ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
