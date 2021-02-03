using System.Threading.Tasks;

namespace PowerBuddy.App.Services.Account
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
