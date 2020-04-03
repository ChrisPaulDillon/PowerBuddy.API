using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Services.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.Repository.Util;
using PowerLifting.Services.ProgramLogs;
using Z.EntityFramework.Plus;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        public ProgramLogRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<ProgramLog> GetTodaysProgramLogByUserId(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId && x.StartDate >= DateTime.Now)
                                                                        .Include(k => k.ProgramLogExercises)     
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }

        public async Task<ProgramLog> GetWeeklyProgramLogByUserId(string userId)
        {
            List<DateTime> weeklyRange = DateHelper.Instance.GetWeekRangeOfCurrentWeek();
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId).Include(k => k.ProgramLogExercises
                                                                        .Where(x => x.LiftingDate.Date > weeklyRange[0] && x.LiftingDate.Date < weeklyRange[1]))
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }

        public async Task<ProgramLog> GetProgramLogByProgramLogId(int programLogId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == programLogId).Include(k => k.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }

        public async Task<ProgramLog> GetActiveProgramLogByUserId(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.EndDate < DateTime.Now && x.UserId == userId).
                                                                                                Include(k => k.ProgramLogExercises.Select(c => c.ProgramLogRepSchemes)).
                                                                                                FirstOrDefaultAsync();
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
