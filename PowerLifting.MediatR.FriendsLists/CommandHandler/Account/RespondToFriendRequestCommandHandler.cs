using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.FriendsLists.Command.Account;

namespace PowerLifting.MediatR.FriendsLists.CommandHandler.Account
{
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
                .FirstOrDefaultAsync(x => x.FriendRequestId == request.FriendRequestId && x.UserToId == request.UserId, cancellationToken: cancellationToken);

            if (friendRequest == null) throw new FriendRequestNotFoundException();

            friendRequest.HasAccepted = request.Response;

            var friendsListAssoc = new FriendsListAssoc()
            {
                UserId = friendRequest.UserFromId,
                OtherUserId = friendRequest.UserToId
            };

            _context.FriendsListAssoc.Add(friendsListAssoc);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}