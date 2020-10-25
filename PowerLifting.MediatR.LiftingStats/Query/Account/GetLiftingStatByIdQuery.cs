using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Query.Account
{
    public class GetLiftingStatByIdQuery : IRequest<LiftingStatDetailedDTO>
    {
        public int LiftingStatId { get; set; }
        public string UserId { get; }

        public GetLiftingStatByIdQuery(int liftingStatId, string userId)
        {
            LiftingStatId = liftingStatId;
            UserId = userId;
        }
    }
}