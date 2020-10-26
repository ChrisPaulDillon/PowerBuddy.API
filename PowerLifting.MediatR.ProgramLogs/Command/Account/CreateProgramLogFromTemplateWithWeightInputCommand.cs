using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
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
            new CreateProgramLogFromTemplateWithWeightInputCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogFromTemplateWithWeightInputCommandValidator : AbstractValidator<CreateProgramLogFromTemplateWithWeightInputCommand>
    {
        public CreateProgramLogFromTemplateWithWeightInputCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ProgramLogDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.ProgramLogDTO.UserId).Matches(x => x.UserId).WithMessage("'{PropertyName}' cannot be empty.");
        }
    }
}