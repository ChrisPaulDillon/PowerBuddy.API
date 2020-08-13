using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.Mediatr.Query.Exercises.Public
{
    public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    { 
        public GetAllExercisesQuery()
        {
        }
    }
}