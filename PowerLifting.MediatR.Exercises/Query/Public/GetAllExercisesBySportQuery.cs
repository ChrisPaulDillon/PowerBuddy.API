using System.Collections.Generic;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediatR.Exercises.Query.Public
{
    public class GetAllExercisesBySportQuery : IRequest<IEnumerable<TopLevelExerciseDTO>>
    {
        public string ExerciseSport { get; }
        public GetAllExercisesBySportQuery(string exerciseSport)
        {
            ExerciseSport = exerciseSport;
        }
    }
}