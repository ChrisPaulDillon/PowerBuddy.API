using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogs.Commands.Account
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

    public class DeleteProgramLogCommandHandler : IRequestHandler<DeleteProgramLogCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DeleteProgramLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProgramLogCommand request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog.FirstOrDefaultAsync(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (programLog == null) throw new ProgramLogNotFoundException();

            _context.ProgramLog.Remove(programLog);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
