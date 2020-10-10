using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.Exercises;
using MediatR;

namespace PowerLifting.MediatR.ExerciseMuscleGroups.Query.Public
{
    public class GetAllExerciseMuscleGroupsQuery : IRequest<IEnumerable<ExerciseMuscleGroupDTO>>
    {
        public GetAllExerciseMuscleGroupsQuery()
        {
        }
    }
}