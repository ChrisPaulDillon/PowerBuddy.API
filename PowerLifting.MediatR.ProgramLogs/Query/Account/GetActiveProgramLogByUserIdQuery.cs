using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Query.Account
{
    public class GetActiveProgramLogByUserIdQuery : IRequest<ProgramLogDTO>
    {
        public string UserId { get; }

        public GetActiveProgramLogByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
