using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Query.Account
{
    public class GetProgramLogDayByDateQuery : IRequest<ProgramLogDayDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetProgramLogDayByDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
        }
    }
}
