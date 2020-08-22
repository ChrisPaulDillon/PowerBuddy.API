using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.MediatR.Users.Command.Account
{
    public class CreateFirstVisitStatsCommand : IRequest<bool>
    {
        public FirstVisitDTO FirstVisitDTO { get; }
        public string UserId { get; }

        public CreateFirstVisitStatsCommand(FirstVisitDTO firstVisitDTO, string userId)
        {
            FirstVisitDTO = firstVisitDTO;
            UserId = userId;
        }
    }
}
