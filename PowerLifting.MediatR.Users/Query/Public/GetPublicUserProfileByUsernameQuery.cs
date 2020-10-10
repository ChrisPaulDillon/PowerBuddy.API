using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.MediatR.Users.Query.Public
{ 
    public class GetPublicUserProfileByUsernameQuery : IRequest<PublicUserDTO>
    {
        public string Username { get; }

        public GetPublicUserProfileByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
