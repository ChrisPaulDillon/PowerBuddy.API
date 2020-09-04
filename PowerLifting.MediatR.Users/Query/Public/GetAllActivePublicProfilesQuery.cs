using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.Users.Query.Public
{ 
    public class GetAllActivePublicProfilesQuery : IRequest<IEnumerable<PublicUserDTO>>
    {
        public string UserId { get;}
        public GetAllActivePublicProfilesQuery(string userId)
        {
            UserId = userId;
        }
    }
}
