using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class UpdateLiftingStatCollectionCommand : IRequest<bool>
    {
        public IEnumerable<LiftingStatDTO> LiftingStatCollection { get; }
        public string UserId { get; }

        public UpdateLiftingStatCollectionCommand(IEnumerable<LiftingStatDTO> liftingStatCollection, string userId)
        {
            LiftingStatCollection = liftingStatCollection;
            UserId = userId;
        }
    }
}