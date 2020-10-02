using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.Command.Account
{
    public class UpdateProgramLogCommand : IRequest<bool>
    {
        public ProgramLogDTO ProgramLogDTO { get; }
        public string UserId { get; }

        public UpdateProgramLogCommand(ProgramLogDTO programLogDTO, string userId)
        {
            ProgramLogDTO = programLogDTO;
            UserId = userId;
            new UpdateProgramLogCommandValidator().ValidateAndThrow(this);
        }
    }

    public class UpdateProgramLogCommandValidator : AbstractValidator<UpdateProgramLogCommand>
    {
        public UpdateProgramLogCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.ProgramLogDTO.UserId).Matches(x => x.UserId).WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.CustomName).MaximumLength(180).WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }
}