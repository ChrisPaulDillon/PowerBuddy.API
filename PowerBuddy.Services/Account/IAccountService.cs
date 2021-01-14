using System.Threading.Tasks;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.Account
{
    public interface IAccountService
    {
        bool IsUserModerator(string userId);

        Task<bool> IsUserProfilePublic(string userId);

        Task<int> GetTotalUserCount();
    }
}
