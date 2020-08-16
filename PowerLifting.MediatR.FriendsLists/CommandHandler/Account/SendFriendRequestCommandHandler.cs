using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.FriendsLists.Command.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.FriendsLists.CommandHandler.Account
{
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
            var doesFriendExist = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.FriendUserId);

            if (!doesFriendExist) return false;

            var doesRequestExist = await _context.FriendRequest
                .AsNoTracking()
                .AnyAsync(x => x.UserFromId == request.UserId && x.UserToId == request.FriendUserId ||
                               x.UserFromId == request.FriendUserId && x.UserToId == request.UserId
                    , cancellationToken: cancellationToken);

            if (doesRequestExist) return false;

            var friendsListReq = new FriendRequest() { UserToId = request.FriendUserId, UserFromId = request.UserId };
            _context.FriendRequest.Add(friendsListReq);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}