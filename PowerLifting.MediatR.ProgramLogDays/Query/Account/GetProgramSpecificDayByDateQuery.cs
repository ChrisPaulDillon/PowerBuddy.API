using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Query.Account
{
    public class GetProgramSpecificDayByDateQuery : IRequest<ProgramLogDayDTO>
    {
        public DateTime Date { get; }
        public int ProgramLogId { get; }
        public string UserId { get; }

        public GetProgramSpecificDayByDateQuery(DateTime date, int programLog, string userId)
        {
            Date = date;
            ProgramLogId = ProgramLogId;
            UserId = userId;
        }
    }
}
