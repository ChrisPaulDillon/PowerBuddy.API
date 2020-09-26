using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Command.Member
{
    public class UpdateProgramLogDayMemberCommand : IRequest<IEnumerable<LiftingStatDTO>>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogDayMemberCommand(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            UserId = userId;
        }
    }
}