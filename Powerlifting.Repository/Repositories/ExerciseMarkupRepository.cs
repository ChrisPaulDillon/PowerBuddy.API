using Powerlifting.Repository;
using PowerLifting.ExerciseMarkups.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ExerciseMarkups;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseMarkupRepository : RepositoryBase<ExerciseMarkup>, IExerciseMarkupRepository
    {
        public ExerciseMarkupRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
