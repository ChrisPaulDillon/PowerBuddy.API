using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogDays;
using PowerLifting.Service.ProgramLogDays.Model;

namespace PowerLifting.Repository.Repositories.ProgramLogs
{
    public class ProgramLogDayRepository : RepositoryBase<ProgramLogDay>, IProgramLogDayRepository
    {
        public ProgramLogDayRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<ProgramLogDay> GetProgramLogDay(string userId, DateTime dateSelected)
        {
            return await PowerliftingContext.Set<ProgramLogDay>().Where(x => x.UserId == userId && x.Date == dateSelected).FirstOrDefaultAsync();
        }

        public void UpdateProgramLogDay(ProgramLogDay programLogDay)
        {
            Update(programLogDay);
            Save();
        }

        public void DeleteProgramLogDay(ProgramLogDay programLogDay)
        {
            Delete(programLogDay);
            Save();
        }
    }
}
