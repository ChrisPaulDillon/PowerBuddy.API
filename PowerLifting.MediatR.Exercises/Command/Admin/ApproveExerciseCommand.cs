using MediatR;

namespace PowerLifting.MediatR.Exercises.Command.Admin
{
    public class ApproveExerciseCommand : IRequest<bool>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public ApproveExerciseCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }
}