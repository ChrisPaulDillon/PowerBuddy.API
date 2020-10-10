using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class CreateLiftingStatCollectionCommand : IRequest<bool>
    {
        public IEnumerable<LiftingStatDTO> LiftingStatCollection { get; }
        public string UserId { get; }

        public CreateLiftingStatCollectionCommand(IEnumerable<LiftingStatDTO> liftingStatCollection, string userId)
        {
            LiftingStatCollection = liftingStatCollection;
            UserId = userId;
        }
    }
}