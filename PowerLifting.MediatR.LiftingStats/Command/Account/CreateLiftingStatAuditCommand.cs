using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class CreateLiftingStatAuditCommand : IRequest<Unit>
    {
        public int LiftingStatId { get; }
        public int ExerciseId { get; }
        public int RepRange { get; }
        public decimal Weight { get; }
        public string UserId { get; }

        public CreateLiftingStatAuditCommand(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId)
        {
            LiftingStatId = liftingStatId;
            ExerciseId = exerciseId;
            RepRange = repRange;
            Weight = weight;
            UserId = userId;
        }
    }
}
