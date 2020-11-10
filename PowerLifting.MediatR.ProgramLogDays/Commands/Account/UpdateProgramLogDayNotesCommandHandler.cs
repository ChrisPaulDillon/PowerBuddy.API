using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogDays.Commands.Account
{
    public class UpdateProgramLogDayNotesCommand : IRequest<bool>
    {
        public int ProgramLogDayId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateProgramLogDayNotesCommand(int programLogDayId, string notes, string userId)
        {
            ProgramLogDayId = programLogDayId;
            Notes = notes;
            UserId = userId;
            new UpdateProgramLogDayNotesCommandValidator().ValidateAndThrow(this);
        }
    }

    public class UpdateProgramLogDayNotesCommandValidator : AbstractValidator<UpdateProgramLogDayNotesCommand>
    {
        public UpdateProgramLogDayNotesCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Notes).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateProgramLogDayNotesCommandHandler : IRequestHandler<UpdateProgramLogDayNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogDayNotesCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogDayNotesCommand request, CancellationToken cancellationToken)
        {
            var programLogDay = await _context.ProgramLogDay
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            programLogDay.Comment = request.Notes;

            _context.ProgramLogDay.Update(programLogDay);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}