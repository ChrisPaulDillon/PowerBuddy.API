using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogWeeks.Query.Account
{
    public class GetProgramLogWeekByWeekNoQuery : IRequest<ProgramLogWeekDTO>
    {
        public int ProgramLogId { get; }
        public int WeekNo { get; }

        public GetProgramLogWeekByWeekNoQuery(int programLogId, int weekNo)
        {
            ProgramLogId = programLogId;
            WeekNo = weekNo;
        }
    }
}