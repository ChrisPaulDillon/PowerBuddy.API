using MediatR;

namespace PowerLifting.MediatR.LiftingStats.Command.Account
{
    public class DeleteLiftingStatCommand : IRequest<bool>
    {
        public int LiftingStatId { get; }
        public string UserId { get; }

        public DeleteLiftingStatCommand(int liftingStatId, string userId)
        {
            LiftingStatId = liftingStatId;
            UserId = userId;
        }
    }
}