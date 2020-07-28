using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface IUserSettingService
    {
        Task<UserSettingDTO> GetUserSettingsByUserId(string userId);
    }
}
