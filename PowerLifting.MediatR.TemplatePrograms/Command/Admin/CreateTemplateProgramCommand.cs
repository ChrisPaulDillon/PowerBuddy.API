using MediatR;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Command.Admin
{
    public class CreateTemplateProgramCommand : IRequest<TemplateProgramDTO>
    {
        public TemplateProgramDTO TemplateProgramDTO { get; }
        public string UserId { get; }
        public CreateTemplateProgramCommand(TemplateProgramDTO templateProgramDTO, string userId)
        {
            TemplateProgramDTO = templateProgramDTO;
            UserId = userId;
        }
    }
}