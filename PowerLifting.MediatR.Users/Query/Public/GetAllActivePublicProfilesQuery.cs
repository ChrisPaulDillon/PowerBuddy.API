using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Users.Query.Public
{ 
    public class GetAllActivePublicProfilesQuery : IRequest<IEnumerable<PublicUserDTO>>
    {
        public GetAllActivePublicProfilesQuery()
        {
        }
    }
}
