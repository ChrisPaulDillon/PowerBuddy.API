using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

            CreateFriendsListAssoc(friendRequest.UserFromId, friendRequest.UserToId);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public void CreateFriendsListAssoc(string userId, string otherUserId)
        {
            var friendsListAssoc = new FriendsListAssoc()
            {
                UserId = userId,
                OtherUserId = otherUserId
            };

            _context.Add(friendsListAssoc);
        }

        public async Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendsList(string userId)
        {
            return await _context.FriendsListAssoc.Where(x => x.UserId == userId || x.OtherUserId == userId)
                .AsNoTracking()
                .ProjectTo<FriendsListAssocDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
