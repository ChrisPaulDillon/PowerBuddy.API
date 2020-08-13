using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Command.Account
{
    public class CreateExerciseCommand : IRequest<ExerciseDTO>
    {
        public CExerciseDTO Exercise { get; }

        public CreateExerciseCommand(CExerciseDTO exercise)
        {
            Exercise = exercise;
        }
    }
}