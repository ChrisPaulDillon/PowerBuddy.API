using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.Entity.Account.DTOs;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Accounts.Service.Services
{
    public class FriendsListService : IFriendsListService
    {
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;
        private readonly UserManager<User> _userManager;

        public FriendsListService(IAccountWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<FriendRequestDTO> GetPendingFriendRequest(string friendUserId, string userId)
        {
            return await _repo.FriendsList.GetPendingFriendRequest(friendUserId, userId);
        }

        public async Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendList(string userId)
        {
            return await _repo.FriendsList.GetUsersFriendsList(userId);
        }

        public async Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId)
        {
            return await _repo.FriendsList.RespondToFriendRequest(friendsListId, response, userId);
        }

        public async Task<bool> SendFriendsRequest(string friendUserId, string userId)
        {
            var friendUser = await _userManager.FindByIdAsync(friendUserId);
            if (friendUser == null) return false;

            var doesRequestExist = await _repo.FriendsList.DoesFriendRequestExist(friendUserId, userId);

            if (doesRequestExist) return false;

            return await _repo.FriendsList.SendFriendRequest(friendUserId, userId);
        }
    }
}
