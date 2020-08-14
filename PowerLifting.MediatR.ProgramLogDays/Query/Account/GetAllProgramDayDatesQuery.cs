using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Query.Account
{
    public class GetAllProgramDayDatesQuery : IRequest<IEnumerable<DateTime>>
    {
        public string UserId { get; }

        public GetAllProgramDayDatesQuery(string userId)
        {
            UserId = userId;
        }
    }
}