using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogWeekRepository : RepositoryBase<ProgramLogWeek>, IProgramLogWeekRepository
    {
        public ProgramLogWeekRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<ProgramLogWeek> GetCurrentProgramLogWeekByUserId(string userId)
        {
            //var currentWeek = DateHelper.Instance.GetWeekRangeOfCurrentWeek();
            return await PowerliftingContext.Set<ProgramLogWeek>().Where(x => x.UserId == userId
                                                                         && x.StartDate >= DateTime.Now.Date
                                                                         && DateTime.Now.Date <= x.EndDate)
                                                                        .Include(k => k.ProgramLogDays)
                                                                        .ThenInclude(e => e.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }

        public async Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId)
        {
            return await PowerliftingContext.Set<ProgramLogWeek>().Where(x => x.ProgramLogWeekId == programLogWeekId)
                                                                        .Include(k => k.ProgramLogDays)
                                                                        .ThenInclude(e => e.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }
    }
}
