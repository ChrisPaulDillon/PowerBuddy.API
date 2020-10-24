using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Query.Public
{
    public class GetExerciseByIdQuery : IRequest<ExerciseDTO>
    {
        public int ExerciseId { get; }

        public GetExerciseByIdQuery(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}