using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogWeekRepository : IRepositoryBase<ProgramLogWeek>
    {
        Task<ProgramLogWeek> GetCurrentProgramLogWeekByUserId(string userId);
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
    }
}