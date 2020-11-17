using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.FriendsLists.Commands.Account
{
    public class RespondToFriendRequestCommand : IRequest<bool>
    {
        public string FriendUserId { get; }
        public bool Response { get; }
        public string UserId { get; }
        public RespondToFriendRequestCommand(string friendUserId, bool response, string userId)
        {
            FriendUserId = friendUserId;
            Response = response;
            UserId = userId;
        }
    }

    public class RespondToFriendRequestCommandHandler : IRequestHandler<RespondToFriendRequestCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public RespondToFriendRequestCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RespondToFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var friendRequest = await _context.FriendRequest
                .FirstOrDefaultAsync(x => x.UserFromId == request.FriendUserId && x.UserToId == request.UserId, cancellationToken: cancellationToken);

            if (friendRequest == null) throw new FriendRequestNotFoundException();

            friendRequest.HasAccepted = request.Response;

            if (request.Response)
            {
                var friendsListAssoc = new FriendsListAssoc()
                {
                    UserId = friendRequest.UserFromId,
                    OtherUserId = friendRequest.UserToId
                };

                _context.FriendsListAssoc.Add(friendsListAssoc);
            }

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}