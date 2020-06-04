using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts
{
    public interface IProgramLogWeekRepository : IRepositoryBase<ProgramLogWeek>
    {
        Task<ProgramLogWeek> GetCurrentProgramLogWeekByUserId(string userId);
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
    }
}