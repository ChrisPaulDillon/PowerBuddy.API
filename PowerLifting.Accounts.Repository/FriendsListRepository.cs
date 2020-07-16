using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Entity.Account.DTOs;
using PowerLifting.Entity.Account.Models;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Repository
{
    public class FriendsListRepository : IFriendsListRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public FriendsListRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> GetFriendRequest(string userId, string otherUserId)
        {
            return await _context.FriendsList.AnyAsync(x => x.UserFromId == userId && x.UserToId == otherUserId);
        }

        public async Task<bool> SendFriendRequest(FriendsListDTO request)
        {
            var friendsListReq = _mapper.Map<FriendsList>(request);
            _context.Add(friendsListReq);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> RespondToFriendRequest(int friendsListId, bool response, string userId)
        {
            var friendRequest = await _context.FriendsList.FirstOrDefaultAsync(x => x.FriendsListId == friendsListId && x.UserToId == userId);
            if (friendRequest != null) friendRequest.HasAccepted = response;

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}
