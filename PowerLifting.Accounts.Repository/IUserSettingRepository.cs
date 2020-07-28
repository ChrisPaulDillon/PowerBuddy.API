using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Repository
{
    public interface IUserSettingRepository
    {
        Task<UserSettingDTO> GetUserSettingsById(string userId);
    }
}
