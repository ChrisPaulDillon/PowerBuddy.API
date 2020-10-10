using FluentValidation;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class DeleteProgramLogCommand : IRequest<bool>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public DeleteProgramLogCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
            new DeleteProgramLogCommandValidator().ValidateAndThrow(this);
        }
    }

    public class DeleteProgramLogCommandValidator : AbstractValidator<DeleteProgramLogCommand>
    {
        public DeleteProgramLogCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }
}