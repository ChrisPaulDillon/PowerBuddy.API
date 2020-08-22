﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Command.Account
{
    public class UpdateProgramLogDayCommand : IRequest<bool>
    {
        public ProgramLogDayDTO ProgramLogDayDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogDayCommand(ProgramLogDayDTO programLogDayDTO, string userId)
        {
            ProgramLogDayDTO = programLogDayDTO;
            UserId = userId;
        }
    }
}