using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Command.Account
{
    public class CreateProgramLogDayCommand : IRequest<ProgramLogDayDTO>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public string UserId { get; }

        public CreateProgramLogDayCommand(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            UserId = userId;
        }
    }
}
