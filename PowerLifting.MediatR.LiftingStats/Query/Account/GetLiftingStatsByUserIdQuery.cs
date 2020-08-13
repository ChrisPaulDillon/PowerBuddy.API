using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.LiftingStats.Query.Account
{
    public class GetLiftingStatsByUserIdQuery : IRequest<IEnumerable<LiftingStatDTO>>
    {
        public string UserId { get; }
        public GetLiftingStatsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}