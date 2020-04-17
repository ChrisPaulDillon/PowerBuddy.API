using System;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogWeeks.Model;

namespace PowerLifting.Service.ProgramLogWeeks
{
    public interface IProgramLogWeekRepository
    {
        Task<ProgramLogWeek> GetCurrentProgramLogWeek(string userId);
    }
}
