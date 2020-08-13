using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class UpdateLiftingStatCommand : IRequest<bool>
    {
        public LiftingStatDTO LiftingStatDTO { get; }

        public UpdateLiftingStatCommand(LiftingStatDTO liftingStatDTO)
        {
            LiftingStatDTO = liftingStatDTO;
        }
    }
}