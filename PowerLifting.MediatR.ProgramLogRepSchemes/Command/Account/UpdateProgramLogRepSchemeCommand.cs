using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account
{
    public class UpdateProgramLogRepSchemeCommand : IRequest<bool>
    {
        public ProgramLogRepSchemeDTO ProgramLogRepSchemeDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogRepSchemeCommand(ProgramLogRepSchemeDTO programLogRepSchemeDTO, string userId)
        {
            ProgramLogRepSchemeDTO = programLogRepSchemeDTO;
            UserId = userId;
        }
    }
}
