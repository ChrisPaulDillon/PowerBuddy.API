using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.Mediatr.Command.Exercises.Admin
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