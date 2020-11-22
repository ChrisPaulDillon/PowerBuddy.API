using System.Threading.Tasks;

namespace PowerBuddy.Services.Account
{
    public interface IAccountService
    {
        bool IsUserModerator(string userId);

        Task<bool> IsUserProfilePublic(string userId);
    }
}
