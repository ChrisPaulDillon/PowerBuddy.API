using Powerlifting.Repository;
using PowerLifting.ProgramLogExercises.Model;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogExercises;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogRepSchemes.Model;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogExerciseRepository : RepositoryBase<ProgramLogExercise>, IProgramLogExerciseRepository
    {
        public ProgramLogExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            await PowerliftingContext.Set<ProgramLogRepScheme>().AddAsync(programLogRepScheme);
        }

        public void DeleteProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Delete(programLogExercise);
            Save();
        }

        public void UpdateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Update(programLogExercise);
            Save();
        }
    }
}
