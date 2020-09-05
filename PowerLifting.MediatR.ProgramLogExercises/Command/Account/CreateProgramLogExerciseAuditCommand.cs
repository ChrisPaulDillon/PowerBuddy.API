using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.ProgramLogExercises.Command.Account
{
    public class CreateProgramLogExerciseAuditCommand : IRequest<Unit>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public CreateProgramLogExerciseAuditCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }
}
