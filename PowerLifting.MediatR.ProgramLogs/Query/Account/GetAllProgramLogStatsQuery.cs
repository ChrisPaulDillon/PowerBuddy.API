using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.QueryHandler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ProgramLogs.Query.Account
{
    public class GetAllProgramLogStatsQuery : IRequest<ProgramLogStatExtendedDTO>
    {
        public string UserId { get; }

        public GetAllProgramLogStatsQuery(string userId)
        {
            UserId = userId;
        }
    }
}