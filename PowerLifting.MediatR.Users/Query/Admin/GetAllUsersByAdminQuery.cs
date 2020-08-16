using MediatR;
using PowerLifting.Data.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.Users.Query.Admin
{
    public class GetAllUsersByAdminQuery : IRequest<IEnumerable<AdminUserDTO>>
    {
        public string UserId { get; }

        public GetAllUsersByAdminQuery(string userId)
        {
            UserId = userId;
        }
    }
}
