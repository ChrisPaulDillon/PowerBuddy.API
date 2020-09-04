using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromTemplateWithWeightInputCommand : IRequest<ProgramLogDTO>
    {
        public CProgramLogWeightInputDTO ProgramLogDTO { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateProgramLogFromTemplateWithWeightInputCommand(CProgramLogWeightInputDTO programLogDTO, int templateProgramId, string userId)
        {
            ProgramLogDTO = programLogDTO;
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }
}