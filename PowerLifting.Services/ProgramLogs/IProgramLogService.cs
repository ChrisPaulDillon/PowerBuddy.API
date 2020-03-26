using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogs.DTO;

namespace Powerlifting.Services.ProgramLogs
{
    public interface IProgramLogService
    {
        Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(int userId);
        Task<IEnumerable<ProgramLogDTO>> GetActiveProgramLogsByUserId(int userId);
        Task<ProgramLogDTO> GetProgramLogById(int id);
        void UpdateProgramLog(ProgramLogDTO programLog);
        void DeleteProgramLog(ProgramLogDTO programLog);
    }
}
