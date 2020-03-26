using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogs;

namespace PowerLifting.Services.ProgramLogs
{
    public interface IProgramLogRepository
    {
        Task<IEnumerable<ProgramLog>> GetAllProgramLogsByUserId(int userId);
        Task<IEnumerable<ProgramLog>> GetActiveProgramLogsByUserId(int userId);
        Task<ProgramLog> GetProgramLogById(int id);
        void UpdateProgramLog(ProgramLog log);
        void DeleteProgramLog(ProgramLog log);
    }
}
