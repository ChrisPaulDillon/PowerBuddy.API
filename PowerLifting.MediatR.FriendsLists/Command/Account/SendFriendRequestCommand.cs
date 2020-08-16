using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.FriendsLists.Command.Account
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
}

