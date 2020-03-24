using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.Model;

namespace Powerlifting.Contracts.Contracts
{
    public interface IProgramLogService : IServiceBase<ProgramLog>
    {
        Task<IEnumerable<ProgramLog>> GetAllProgramLogs();
        Task<IEnumerable<ProgramLog>> GetActiveProgramLogs();
        Task<ProgramLog> GetProgramLogById(int id);
        void UpdateProgramLog(ProgramLog programLog);
        void DeleteProgramLog(ProgramLog programLog);
    }
}
