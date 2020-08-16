using MediatR;
using PowerLifting.Data.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Account;

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
