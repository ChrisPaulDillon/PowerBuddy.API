using MediatR;
using PowerLifting.Data.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.FriendsLists.Query.Account
{
    public class GetAllPendingFriendRequestsQuery : IRequest<IEnumerable<FriendRequestDTO>>
    {
        public string UserId { get; }
        public GetAllPendingFriendRequestsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
