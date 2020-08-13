using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromTemplateCommand : IRequest<ProgramLog>
    {
        public CProgramLogDTO ProgramLogDTO { get; }
        public TemplateProgramDTO TemplateProgramDTO { get; }
        public string UserId { get; }

        public CreateProgramLogFromTemplateCommand(CProgramLogDTO programLogDTO, TemplateProgramDTO templateProgram, string userId)
        {
            ProgramLogDTO = programLogDTO;
            TemplateProgramDTO = templateProgram;
            UserId = userId;
        }
    }
}