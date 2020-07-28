using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Repository
{
    public class FriendsListRepository : IFriendsListRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public FriendsListRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DoesFriendRequestExist(string friendUserId, string userId)
        {
            return await _context.FriendRequest.AnyAsync(x => x.UserFromId == userId && x.UserToId == friendUserId);
        }

        public async Task<bool> SendFriendRequest(string friendUserId, string userId)
        {
            var friendsListReq = new FriendRequest() { UserToId = friendUserId, UserFromId = userId };
            _context.Add(friendsListReq);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> RespondToFriendRequest(int friendsRequestId, bool response, string userId)
        {
            var friendRequest = await _context.FriendRequest.FirstOrDefaultAsync(x => x.FriendRequestId == friendsRequestId && x.UserToId == userId);
            if (friendRequest != null) friendRequest.HasAccepted = response;

            CreateFriendsListAssoc(friendRequest.UserFromId, friendRequest.UserToId);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public void CreateFriendsListAssoc(string otherUserId, string userId)
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

        public async Task<FriendRequestDTO> GetPendingFriendRequest(string friendUserId, string userId)
        {
            return await _context.FriendRequest.Where(x => x.UserFromId == friendUserId && x.UserToId == userId || x.UserFromId == userId && x.UserToId == friendUserId)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FriendRequestDTO>> GetAllPendingFriendRequests(string userId)
        {
            return await _context.FriendRequest.Where(x => x.UserFromId == userId && x.UserToId == userId && x.HasAccepted == null || x.UserFromId == userId && x.UserToId == userId && x.HasAccepted == null)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
