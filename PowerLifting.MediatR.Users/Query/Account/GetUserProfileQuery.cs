using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.MediatR.Users.Query.Account
{
    public class GetUserProfileQuery : IRequest<UserDTO>
    {
        public string UserId { get; }

        public GetUserProfileQuery(string userId)
        {
            UserId = userId;
        }
    }
}
