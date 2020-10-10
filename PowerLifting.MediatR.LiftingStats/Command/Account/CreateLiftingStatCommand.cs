using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class CreateLiftingStatCommand : IRequest<LiftingStatDTO>
    {
        public LiftingStatDTO LiftingStat { get; }
        public string UserId { get; }

        public CreateLiftingStatCommand(LiftingStatDTO liftingStat, string userId)
        {
            LiftingStat = liftingStat;
            UserId = userId;
        }
    }
}