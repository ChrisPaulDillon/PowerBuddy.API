using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.Users.Command.Admin
{
    public class BanUserCommand : IRequest<bool>
    {
        public string UserId { get; }
        public string AdminUserId { get; }
        public BanUserCommand(string userId, string adminUserId)
        {
            UserId = userId;
            AdminUserId = adminUserId;
        }
    }
}
