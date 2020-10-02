using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.Tonnages.Command.Account
{
    public class CalculateLogTonnageCommand : IRequest<bool>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public CalculateLogTonnageCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }
}