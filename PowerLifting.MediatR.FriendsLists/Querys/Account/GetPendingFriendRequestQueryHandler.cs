using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediatR.FriendsLists.Querys.Account
{
    public class GetPendingFriendRequestQuery : IRequest<FriendRequestDTO>
    {
        public string FriendUserId { get; }
        public string UserId { get; }
        public GetPendingFriendRequestQuery(string friendUserId, string userId)
        {
            FriendUserId = friendUserId;
            UserId = userId;
        }
    }
    public class GetPendingFriendRequestQueryHandler : IRequestHandler<GetPendingFriendRequestQuery, FriendRequestDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetPendingFriendRequestQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FriendRequestDTO> Handle(GetPendingFriendRequestQuery request, CancellationToken cancellationToken)
        {
            var friendReq = await _context.FriendRequest.Where
                    (x => x.UserFromId == request.FriendUserId && x.UserToId == request.UserId || 
                          x.UserFromId == request.UserId && x.UserToId == request.FriendUserId)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (friendReq == null) throw new FriendRequestNotFoundException();

            return friendReq; 
        }
    }
}
