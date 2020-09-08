using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogWeeks.Command.Account
{
    public class AddProgramLogWeekToLogCommand : IRequest<ProgramLogWeekDTO>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public AddProgramLogWeekToLogCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }
}