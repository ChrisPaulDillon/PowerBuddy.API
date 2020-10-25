using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Query.Account
{
    public class GetLiftingStatByIdQuery : IRequest<LiftingStatDetailedDTO>
    {
        public int ExerciseId { get; set; }
        public string UserId { get; }

        public GetLiftingStatByIdQuery(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }
}