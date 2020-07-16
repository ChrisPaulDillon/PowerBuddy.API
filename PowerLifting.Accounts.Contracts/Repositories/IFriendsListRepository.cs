using System.Threading.Tasks;
using PowerLifting.Entity.Account.DTOs;

namespace PowerLifting.Accounts.Contracts.Repositories
{
    public interface IFriendsListRepository
    {
        Task<bool> SendFriendRequest(FriendsListDTO request);

        Task<bool> GetFriendRequest(string userId, string otherUserId);

        Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId);
    }
}
