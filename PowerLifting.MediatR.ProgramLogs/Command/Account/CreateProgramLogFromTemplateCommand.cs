using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromTemplateCommand : IRequest<ProgramLogDTO>
    {
        public CProgramLogDTO ProgramLogDTO { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateProgramLogFromTemplateCommand(CProgramLogDTO programLogDTO, int templateProgramId, string userId)
        {
            ProgramLogDTO = programLogDTO;
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }
}