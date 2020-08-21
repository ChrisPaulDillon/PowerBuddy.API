using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Query.Account
{
    public class GetAllProgramLogCalendarStatsQuery : IRequest<ProgramLogCalendarDTO>
    {
        public string UserId { get; }

        public GetAllProgramLogCalendarStatsQuery(string userId)
        {
            UserId = userId;
        }
    }
}