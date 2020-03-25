using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.Model;

namespace Powerlifting.Contracts.Contracts
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
