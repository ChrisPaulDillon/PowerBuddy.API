using System.Threading.Tasks;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.Account
{
    public interface IAccountService
    {
        Task<bool> DoesUserExist(string userId);
        bool IsUserModerator(string userId);

        Task<bool> IsUserProfilePublic(string userId);

        Task<int> GetTotalUserCount();

        Task<bool> IsUserUsingMetric(string userId);
    }
}
