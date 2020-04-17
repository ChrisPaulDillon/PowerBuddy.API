using System;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogDays.Model;

namespace PowerLifting.Service.ProgramLogDays
{
    public interface IProgramLogDayRepository
    {
        Task<ProgramLogDay> GetProgramLogDay(string userId, DateTime dateSelected);
        void UpdateProgramLogDay(ProgramLogDay programLogDay);
        void DeleteProgramLogDay(ProgramLogDay programLogDay);
    }
}
