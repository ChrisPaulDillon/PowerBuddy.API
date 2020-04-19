using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.ProgramLogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Repository.ProgramLogs
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        public ProgramLogRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ProgramLog>> GetAllProgramLogsByUserId(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId)
                                                                        .Include(x => x.ProgramLogWeeks)
                                                                        .ThenInclude(x => x.ProgramLogDays)
                                                                        .ThenInclude(x => x.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes)
                                                                        .ToListAsync();
        }


        public async Task<ProgramLog> GetProgramLogById(int programLogId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == programLogId).FirstOrDefaultAsync();
        }

        public void CreateProgramLog(ProgramLog programLog)
        {
            Create(programLog);
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
