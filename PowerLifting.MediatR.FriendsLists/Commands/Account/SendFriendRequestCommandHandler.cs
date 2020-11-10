using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities;

namespace PowerLifting.MediatR.FriendsLists.Commands.Account
{
    public class SendFriendRequestCommand : IRequest<bool>
    {
        public string FriendUserId { get; }
        public string UserId { get; }
        public SendFriendRequestCommand(string friendUserId, string userId)
        {
            FriendUserId = friendUserId;
            UserId = userId;
        }
    }

    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public SendFriendRequestCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var doesFriendExist = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.FriendUserId, cancellationToken: cancellationToken);

            if (!doesFriendExist) return false;

            var doesRequestExist = await _context.FriendRequest
                .AsNoTracking()
                .AnyAsync(x => x.UserFromId == request.UserId && x.UserToId == request.FriendUserId ||
                               x.UserFromId == request.FriendUserId && x.UserToId == request.UserId, cancellationToken: cancellationToken);

            if (doesRequestExist) return false;

            var friendRequestDTO = new FriendRequestDTO() { UserToId = request.FriendUserId, UserFromId = request.UserId, HasAccepted = null};
            var friendRequest = _mapper.Map<FriendRequest>(friendRequestDTO);

            _context.FriendRequest.Add(friendRequest);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}