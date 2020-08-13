using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ProgramLogWeeks.Query.Account
{
    public class GetProgramLogWeekBetweenDateQuery : IRequest<ProgramLogWeekDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetProgramLogWeekBetweenDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
        }
    }
}