using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Repository
{
    public interface IFriendsListRepository
    {
        Task<bool> SendFriendRequest(string friendUserId, string userId);

        Task<bool> DoesFriendRequestExist(string friendUserId, string userId);

        Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId);

        void CreateFriendsListAssoc(string friendUserId, string userId);

        Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendsList(string userId);

        Task<FriendRequestDTO> GetPendingFriendRequest(string friendUserId, string userId);

        Task<IEnumerable<FriendRequestDTO>> GetAllPendingFriendRequests(string userId);
    }
}
