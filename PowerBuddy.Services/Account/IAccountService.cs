using System.Linq;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.Services.Account
{
    public interface IAccountService
    {
        IQueryable<UserDTO> GetAccountQueryable(string userId);

        IQueryable<ProgramLogDTO> GetProgramLogsQueryable(string userId);

        IQueryable<ProgramLogDTO> GetProgramLogQueryable(string userId);

        IQueryable<LiftingStatDTO> GetLiftingStatsQueryable(string userId);

        bool IsUserModerator(string userId);

        Task<bool> IsUserProfilePublic(string userId);
    }
}
