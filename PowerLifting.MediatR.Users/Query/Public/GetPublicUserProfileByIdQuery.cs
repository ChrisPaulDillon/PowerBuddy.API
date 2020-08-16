using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Users.Query.Public
{
    public class GetPublicUserProfileByIdQuery : IRequest<PublicUserDTO>
    {
        public string UserId { get; }

        public GetPublicUserProfileByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
