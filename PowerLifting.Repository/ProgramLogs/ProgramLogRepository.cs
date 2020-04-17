using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.ProgramLogs.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Repository.ProgramLogs
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        public ProgramLogRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<ProgramLog> GetActiveProgramLogByUserId(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId && DateTime.Now <= x.EndDate)
                                                                        .Include(x => x.ProgramLogWeeks)
                                                                        .ThenInclude(x => x.ProgramLogDays)
                                                                        .ThenInclude(x => x.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes)
                                                                        .FirstOrDefaultAsync();
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
