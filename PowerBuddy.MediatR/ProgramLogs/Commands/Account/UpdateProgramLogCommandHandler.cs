using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogs.Commands.Account
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

    public class UpdateProgramLogCommandHandler : IRequestHandler<UpdateProgramLogCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogCommand request, CancellationToken cancellationToken)
        {
            var doesLogExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.ProgramLogId == request.ProgramLogDTO.ProgramLogId && x.UserId == request.UserId);

            if (!doesLogExist) throw new ProgramLogNotFoundException();

            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Update(programLog);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
