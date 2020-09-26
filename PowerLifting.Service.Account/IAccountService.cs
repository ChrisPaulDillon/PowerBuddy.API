using PowerLifting.Data.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Service.Account
{
    public interface IAccountService
    {
        IQueryable<UserDTO> GetAccountQueryable(string userId);

        IQueryable<ProgramLogDTO> GetProgramLogsQueryable(string userId);

        IQueryable<ProgramLogDTO> GetProgramLogQueryable(string userId);

        IQueryable<LiftingStatDTO> GetLiftingStatsQueryable(string userId);

        bool IsUserModerator(string userId);
    }
}
