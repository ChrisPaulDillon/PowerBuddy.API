using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class UpdateLiftingStatCommand : IRequest<bool>
    {
        public LiftingStatDTO LiftingStatDTO { get; }
        public string UserId { get; }

        public UpdateLiftingStatCommand(LiftingStatDTO liftingStatDTO, string userId)
        {
            LiftingStatDTO = liftingStatDTO;
            UserId = userId;
        }
    }
}