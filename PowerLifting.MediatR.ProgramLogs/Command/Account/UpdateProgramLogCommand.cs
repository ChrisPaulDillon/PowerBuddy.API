using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class UpdateProgramLogCommand : IRequest<bool>
    {
        public ProgramLogDTO ProgramLogDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogCommand(ProgramLogDTO programLogDTO, string userId)
        {
            ProgramLogDTO = programLogDTO;
            UserId = userId;
        }
    }
}