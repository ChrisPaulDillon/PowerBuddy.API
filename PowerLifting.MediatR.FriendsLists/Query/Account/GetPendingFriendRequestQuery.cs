using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.FriendsLists.Query.Account
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
}
