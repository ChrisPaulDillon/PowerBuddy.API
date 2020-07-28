using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Service
{
    public interface IUserSettingService
    {
        Task<UserSettingDTO> GetUserSettingsByUserId(string userId);
    }
}
