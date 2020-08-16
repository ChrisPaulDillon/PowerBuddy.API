using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.FriendsLists.Command.Account
{
    public class RespondToFriendRequestCommand : IRequest<bool>
    {
        public int FriendRequestId { get; }
        public bool Response { get; }
        public string UserId { get; }
        public RespondToFriendRequestCommand(int friendRequestId, bool response, string userId)
        {
            FriendRequestId = friendRequestId;
            Response = response;
            UserId = userId;
        }
    }
}

