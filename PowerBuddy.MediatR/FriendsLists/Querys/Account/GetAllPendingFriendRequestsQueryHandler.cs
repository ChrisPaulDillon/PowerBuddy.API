using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Account;

namespace PowerBuddy.MediatR.FriendsLists.Querys.Account
{
    public class GetAllPendingFriendRequestsQuery : IRequest<IEnumerable<FriendRequestDTO>>
    {
        public string UserId { get; }
        public GetAllPendingFriendRequestsQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllPendingFriendRequestsQueryHandler : IRequestHandler<GetAllPendingFriendRequestsQuery, IEnumerable<FriendRequestDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllPendingFriendRequestsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FriendRequestDTO>> Handle(GetAllPendingFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _context.FriendRequest.Where(x =>
                    x.UserToId == request.UserId && x.HasAccepted == null ||
                    x.UserFromId == request.UserId && x.HasAccepted == null)
                .AsNoTracking()
                .ProjectTo<FriendRequestDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
