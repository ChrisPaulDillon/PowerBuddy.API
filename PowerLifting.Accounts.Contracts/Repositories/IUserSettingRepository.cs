using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Contracts.Repositories
{
    public interface IUserSettingRepository
    {
        Task<UserSettingDTO> GetUserSettingsById(string userId);
    }
}
