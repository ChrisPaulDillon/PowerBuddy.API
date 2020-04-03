using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogs;

namespace PowerLifting.Services.ProgramLogs
{
    public interface IProgramLogRepository : IRepositoryBase<ProgramLog>
    {
        Task<ProgramLog> GetCurrentProgramLogByUserId(int userId);
        Task<ProgramLog> GetActiveProgramLogByUserId(int userId);
        void UpdateProgramLog(ProgramLog log);
        void DeleteProgramLog(ProgramLog log);
    }
}
