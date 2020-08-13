using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Command.Admin
{
    public class DeleteExerciseCommand : IRequest<bool>
    {
        public int ExerciseId { get; }

        public DeleteExerciseCommand(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}
