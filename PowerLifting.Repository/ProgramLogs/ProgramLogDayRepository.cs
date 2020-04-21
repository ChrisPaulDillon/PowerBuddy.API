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
    public class ProgramLogDayRepository : RepositoryBase<ProgramLogDay>, IProgramLogDayRepository
    {
        public ProgramLogDayRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<ProgramLogDay> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected)
        {
            return await PowerliftingContext.Set<ProgramLogDay>().Where(x => x.UserId == userId
                                                                        && DateTime.Compare(dateSelected.Date, x.Date.Date) == 0
                                                                        && x.ProgramLogWeekId == programLogId) //TODO FIX
                                                                        .FirstOrDefaultAsync();
        }

        public void CreateProgramLogDay(ProgramLogDay programLogDay)
        {
            Create(programLogDay);
        }

        public void UpdateProgramLogDay(ProgramLogDay programLogDay)
        {
            Update(programLogDay);
        }

        public void DeleteProgramLogDay(ProgramLogDay programLogDay)
        {
            Delete(programLogDay);
        }
    }
}
