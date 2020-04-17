using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogWeeks;
using PowerLifting.Service.ProgramLogWeeks.Model;

namespace PowerLifting.Repository.Repositories.ProgramLogs
{
    public class ProgramLogWeekRepository : RepositoryBase<ProgramLogWeek>, IProgramLogWeekRepository
    {
        public ProgramLogWeekRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<ProgramLogWeek> GetCurrentProgramLogWeek(string userId)
        {
            return await PowerliftingContext.Set<ProgramLogWeek>().Where(x => x.UserId == userId && DateTime.Now <= x.EndDate)
                                                                        .Include(k => k.ProgramLogDays)
                                                                        .ThenInclude(e => e.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }
    }
}
