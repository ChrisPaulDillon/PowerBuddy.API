using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseAuditRepository : RepositoryBase<ProgramLogExerciseAudit>, IProgramLogExerciseAuditRepository
    {
        public ProgramLogExerciseAuditRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAudit(string userId, int exerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExerciseAudit>().Where(x => x.UserId == userId
                                                              && x.ExerciseId == exerciseId) 
                                                              .FirstOrDefaultAsync();
        }


        public void CreateProgramLogExerciseAudit(ProgramLogExerciseAudit audit)
        {
            Create(audit);
        }

        public void UpdateProgramLogExerciseAudit(ProgramLogExerciseAudit audit)
        {
            Update(audit);
        }
    }
}
