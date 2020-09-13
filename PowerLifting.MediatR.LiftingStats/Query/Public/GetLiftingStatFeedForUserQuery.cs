using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Query.Public
{
    public class GetLiftingStatFeedForUserQuery : IRequest<IEnumerable<LiftFeedDTO>>
    {
        public string UserName { get; }
        public string UserId { get; }

        public GetLiftingStatFeedForUserQuery(string userName, string userId)
        {
            UserName = userName;
            UserId = userId;
        }
    }
}
