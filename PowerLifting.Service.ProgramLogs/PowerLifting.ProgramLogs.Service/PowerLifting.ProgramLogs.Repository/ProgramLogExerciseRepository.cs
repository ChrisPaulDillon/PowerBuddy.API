using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseRepository : RepositoryBase<ProgramLogExercise>, IProgramLogExerciseRepository
    {
        public ProgramLogExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProgramLogExercise>> GetProgramExercisesByProgramLogDayId(int programLogDayId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>().Where(x => x.ProgramLogDayId == programLogDayId).ToListAsync();
        }

        public void CreateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Create(programLogExercise);
        }

        public void DeleteProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Delete(programLogExercise);
        }

        public async Task<ProgramLogExercise> GetProgramLogExercise(int programLogExerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>().Where(x => x.ProgramLogExerciseId == programLogExerciseId).FirstOrDefaultAsync();                
        }

        public void UpdateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Update(programLogExercise);
        }
    }
}
