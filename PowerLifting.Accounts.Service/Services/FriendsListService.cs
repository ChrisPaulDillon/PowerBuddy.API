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

        public async Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendList(string userId)
        {
            return await _repo.FriendsList.GetUsersFriendsList(userId);
        }

        public async Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId)
        {
            return await _repo.FriendsList.RespondToFriendRequest(friendsListId, response, userId);
        }

        public async Task<bool> SendFriendsRequest(FriendsListDTO request)
        {
            var doesOtherUserExist = await _userManager.FindByIdAsync(request.UserToId);
            var doesRequestExist = await _repo.FriendsList.GetFriendRequest(request.UserFromId, request.UserToId);

            if (doesRequestExist || doesOtherUserExist.Id == null)
            {
                return false;
            }

            return await _repo.FriendsList.SendFriendRequest(request);
        }
    }
}
