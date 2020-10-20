using FluentValidation;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromTemplateCommand : IRequest<ProgramLogDTO>
    {
        public ProgramLogInputDTO ProgramLogDTO { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateProgramLogFromTemplateCommand(ProgramLogInputDTO programLogDTO, int templateProgramId, string userId)
        {
            ProgramLogDTO = programLogDTO;
            TemplateProgramId = templateProgramId;
            UserId = userId;
            new CreateProgramLogFromTemplateCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogFromTemplateCommandValidator : AbstractValidator<CreateProgramLogFromTemplateCommand>
    {
        public CreateProgramLogFromTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.ProgramLogDTO.CustomName).MaximumLength(180).WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }
}