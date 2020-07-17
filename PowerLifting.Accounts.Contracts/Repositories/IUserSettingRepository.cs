using System.Threading.Tasks;
using PowerLifting.Service.UserSettings.DTO;

namespace PowerLifting.Accounts.Contracts.Repositories
{
    public interface IUserSettingRepository
    {
        Task<UserSettingDTO> GetUserSettingsById(string userId);
    }
}
