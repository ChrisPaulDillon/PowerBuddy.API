using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Services.TemplateExercises;
using Powerlifting.Services.TemplateExercises.Model;

namespace PowerLifting.Repository.Repositories
{
    public class TemplateExerciseRepository : RepositoryBase<TemplateExercise>, ITemplateExerciseRepository
    {
        public TemplateExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
