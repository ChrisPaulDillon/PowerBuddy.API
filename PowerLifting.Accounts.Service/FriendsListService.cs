using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Accounts.Service.Wrapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service
{
    public class FriendsListService : IFriendsListService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;
        private readonly UserManager<User> _userManager;

        public FriendsListService(PowerLiftingContext context, IAccountWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<FriendRequestDTO>> GetAllPendingFriendRequests(string userId)
        {
            return await _context.FriendRequest.Where(x => x.UserFromId == userId && x.UserToId == userId && x.HasAccepted == null || x.UserFromId == userId && x.UserToId == userId && x.HasAccepted == null)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<FriendRequestDTO> GetPendingFriendRequest(string friendUserId, string userId)
        {
            var friendReq =  await _context.FriendRequest.Where(x => x.UserFromId == friendUserId && x.UserToId == userId || x.UserFromId == userId && x.UserToId == friendUserId)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (friendReq == null) throw new FriendRequestNotFoundException();

            return friendReq;
        }

        public async Task<IEnumerable<FriendsListAssocDTO>> GetUsersFriendList(string userId)
        {
            return await _context.FriendsListAssoc.Where(x => x.UserId == userId || x.OtherUserId == userId)
                .AsNoTracking()
                .ProjectTo<FriendsListAssocDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> RespondToFriendRequest(int friendsRequestId, bool response, string userId)
        {
            var friendRequest = await _context.FriendRequest.FirstOrDefaultAsync(x => x.FriendRequestId == friendsRequestId && x.UserToId == userId);
            
            if (friendRequest == null) throw new FriendRequestNotFoundException();
            
             friendRequest.HasAccepted = response;

            var friendsListAssoc = new FriendsListAssoc()
            {
                UserId = friendRequest.UserFromId,
                OtherUserId = friendRequest.UserToId
            };

            _context.Add(friendsListAssoc);

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> SendFriendsRequest(string friendUserId, string userId)
        {
            var friendUser = await _userManager.FindByIdAsync(friendUserId);
            if (friendUser == null) return false;

            var doesRequestExist = await _context.FriendRequest.AnyAsync(x => x.UserFromId == userId && x.UserToId == friendUserId);

            if (doesRequestExist) return false;

            var friendsListReq = new FriendRequest() { UserToId = friendUserId, UserFromId = userId };
            _context.Add(friendsListReq);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}
