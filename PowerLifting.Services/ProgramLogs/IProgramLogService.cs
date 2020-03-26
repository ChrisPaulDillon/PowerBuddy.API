using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ServiceWrappers;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.Model;

namespace Powerlifting.Services.ProgramLogs
{
    public interface IProgramLogService : IServiceBase<ProgramLog>
    {
        Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogs();
        Task<IEnumerable<ProgramLogDTO>> GetActiveProgramLogs();
        Task<ProgramLogDTO> GetProgramLogById(int id);
        void UpdateProgramLog(ProgramLog programLog);
        void DeleteProgramLog(ProgramLog programLog);
    }
}
