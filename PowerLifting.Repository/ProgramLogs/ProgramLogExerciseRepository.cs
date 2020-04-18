using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.ProgramLogs.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Repository.ProgramLogs
{
    public class ProgramLogExerciseRepository : RepositoryBase<ProgramLogExercise>, IProgramLogExerciseRepository
    {
        public ProgramLogExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task CreateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            await Create(programLogExercise);
        }

        public void DeleteProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Delete(programLogExercise);
            Save();
        }

        public async Task<ProgramLogExercise> GetProgramLogExercise(int programLogExerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>().Where(x => x.ProgramLogExerciseId == programLogExerciseId).FirstOrDefaultAsync();                
        }

        public void UpdateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Update(programLogExercise);
            Save();
        }
    }
}
