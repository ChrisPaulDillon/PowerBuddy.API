using System;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogDayRepository : IRepositoryBase<ProgramLogDay>
    {
        Task<ProgramLogDay> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected);
        void UpdateProgramLogDay(ProgramLogDay programLogDay);
        void DeleteProgramLogDay(ProgramLogDay programLogDay);
    }
}