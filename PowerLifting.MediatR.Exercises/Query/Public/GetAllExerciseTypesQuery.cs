using MediatR;
using PowerLifting.Data.DTOs.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ExerciseTypes.Query.Public
{
    public class GetAllExerciseTypesQuery : IRequest<IEnumerable<ExerciseTypeDTO>>
    {

        public GetAllExerciseTypesQuery()
        {
        }
    }
}
