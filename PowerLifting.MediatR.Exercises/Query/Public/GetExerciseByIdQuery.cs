﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.MediatR.Exercises.Query.Public
{
    public class GetExerciseByIdQuery : IRequest<Exercise>
    {
        public int ExerciseId { get; }

        public GetExerciseByIdQuery(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}