using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ProgramLogs.Query.Account
{
    public class GetAllProgramLogsByUserIdQuery : IRequest<IEnumerable<ProgramLogStatDTO>>
    {
        public string UserId { get; }

        public GetAllProgramLogsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}