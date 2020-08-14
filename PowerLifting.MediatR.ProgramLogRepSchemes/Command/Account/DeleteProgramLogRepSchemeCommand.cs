using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account
{
    public class DeleteProgramLogRepSchemeCommand : IRequest<bool>
    {
        public int ProgramLogRepSchemeId { get; }
        public string UserId { get; }

        public DeleteProgramLogRepSchemeCommand(int programLogRepSchemeId, string userId)
        {
            ProgramLogRepSchemeId = programLogRepSchemeId;
            UserId = userId;
        }
    }
}
