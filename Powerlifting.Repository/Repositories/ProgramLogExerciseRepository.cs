using Powerlifting.Repository;
using PowerLifting.ProgramLogExercises.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramLogExercises;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogExerciseRepository : RepositoryBase<ProgramLogExercise>, IProgramLogExerciseRepository
    {
        public ProgramLogExerciseRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
