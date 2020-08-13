using System.Collections.Generic;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Query.Public
{
    public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    {

        public GetAllExercisesQuery()
        {
        }
    }
}