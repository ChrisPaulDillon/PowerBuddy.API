using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PowerLifting.MediatR.ProgramLogDays.Command.Account
{
    public class UpdateProgramLogDayNotesCommand : IRequest<bool>
    {
        public int ProgramLogDayId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateProgramLogDayNotesCommand(int programLogDayId, string notes, string userId)
        {
            ProgramLogDayId = programLogDayId;
            Notes = notes;
            UserId = userId;
        }
    }
}