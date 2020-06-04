using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogWeekRepository : IRepositoryBase<ProgramLogWeek>
    {
        Task<ProgramLogWeek> GetCurrentProgramLogWeekByUserId(string userId);
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
    }
}