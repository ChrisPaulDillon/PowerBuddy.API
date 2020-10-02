using FluentValidation;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class CreateProgramLogFromScratchCommand : IRequest<ProgramLog>
    {
        public CProgramLogDTO ProgramLogDTO { get; }
        public string UserId { get; }

        public CreateProgramLogFromScratchCommand(CProgramLogDTO programLogDTO, string userId)
        {
            ProgramLogDTO = programLogDTO;
            UserId = userId;
            new CreateProgramLogFromScratchCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogFromScratchCommandValidator : AbstractValidator<CreateProgramLogFromScratchCommand>
    {
        public CreateProgramLogFromScratchCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.ProgramLogDTO.UserId).Matches(x => x.UserId)
                .WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.CustomName).MaximumLength(180)
                .WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }
}