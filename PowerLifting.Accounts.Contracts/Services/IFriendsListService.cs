using System;
using System.Threading.Tasks;
using PowerLifting.Entity.Account.DTOs;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface IFriendsListService
    {
        Task<bool> SendFriendsRequest(FriendsListDTO request);
        Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId);
    }
}
