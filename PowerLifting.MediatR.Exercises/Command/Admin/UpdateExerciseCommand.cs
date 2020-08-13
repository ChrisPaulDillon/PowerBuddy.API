using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Command.Admin
{ 
    public class UpdateExerciseCommand : IRequest<bool>
    {
        public ExerciseDTO Exercise { get; }

        public UpdateExerciseCommand(ExerciseDTO exercise)
        {
            Exercise = exercise;
        }
    }
}
