using MediatR;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class DeleteLiftingStatCommand : IRequest<bool>
    {
        public int LiftingStatId { get; }

        public DeleteLiftingStatCommand(int liftingStatId)
        {
            LiftingStatId = liftingStatId;
        }
    }
}