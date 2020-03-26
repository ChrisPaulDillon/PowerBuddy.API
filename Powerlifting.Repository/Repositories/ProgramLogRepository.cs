using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Services.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramLogs;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        public ProgramLogRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ProgramLog>> GetAllProgramLogsByUserId(int userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId).Include(j => j.ProgramTemplate).Include(k => k.ExeciseMarkups).ToListAsync();
        }

        public async Task<ProgramLog> GetProgramLogById(int id)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == id).Include(j => j.ProgramTemplate).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProgramLog>> GetActiveProgramLogsByUserId(int userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.EndDate < DateTime.Now && x.UserId == userId).Include(j => j.ProgramTemplate).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                ToListAsync();
        }
        public void UpdateProgramLog(ProgramLog log)
        {
            PowerliftingContext.Set<ProgramLog>().Where(u => u.ProgramLogId == log.ProgramLogId).AsNoTracking().FirstOrDefaultAsync();
            Save();
        }

        public void DeleteProgramLog(ProgramLog log)
        {
            PowerliftingContext.Set<ProgramLog>().Remove(log);
            Save();
        }

      
    }
}
