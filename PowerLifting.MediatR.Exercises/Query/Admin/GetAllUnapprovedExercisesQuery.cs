using System.Collections.Generic;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.MediatR.Exercises.Query.Admin
{
    public class GetAllUnapprovedExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    {
        public string UserId { get; }
        public GetAllUnapprovedExercisesQuery(string userId)
        {
            UserId = userId;
        }
    }
}