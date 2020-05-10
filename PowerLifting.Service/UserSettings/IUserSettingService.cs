using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.UserSettings.DTO;

namespace PowerLifting.Service.UserSettings
{
    public interface IUserSettingService
    {
        /// <summary>
        /// Gets 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserSettingDTO>> GetUserSettingsByUserId(string userId);
    }
}
