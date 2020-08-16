using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.FriendsLists.Query.Account
{
    public class GetUserFriendsListQuery : IRequest<IEnumerable<FriendsListAssocDTO>>
    {
        public string UserId { get; }
        public GetUserFriendsListQuery(string userId)
        { 
            UserId = userId;
        }
    }
}
