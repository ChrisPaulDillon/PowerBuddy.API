using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.UserSettings.DTO;

namespace PowerLifting.Accounts.Contracts.Services
{ 
    public interface IUserSettingService
    {
        Task<IEnumerable<UserSettingDTO>> GetUserSettingsByUserId(string userId);
    }
}
