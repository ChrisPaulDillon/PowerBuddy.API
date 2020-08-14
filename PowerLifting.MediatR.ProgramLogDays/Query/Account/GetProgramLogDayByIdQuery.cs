using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.ProgramLogDays.Query.Account
{
    public class GetProgramLogDayByIdQuery : IRequest<ProgramLogDayDTO>
    {
        public int ProgramLogDayId { get; }
        public string UserId { get; }

        public GetProgramLogDayByIdQuery(int programLogDayId, string userId)
        {
            ProgramLogDayId = programLogDayId;
            UserId = userId;
        }
    }
}
