using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface IFriendsListService
    {
        Task<bool> SendFriendsRequest(string friendUserId, string userId);

        Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId);

        Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendList(string userId);

        Task<FriendRequestDTO> GetPendingFriendRequest(string id, string userId);

        Task<IEnumerable<FriendRequestDTO>> GetAllPendingFriendRequests(string userId);
    }
}
