using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Query.Account
{
    public class GetProgramLogByIdQuery : IRequest<ProgramLogDTO>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public GetProgramLogByIdQuery(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }
}
