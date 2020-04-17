using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.ProgramLogs.Model;
using System.Threading.Tasks;

namespace PowerLifting.Repository.ProgramLogs
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
