using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.FriendsLists.Command.Account
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
}

