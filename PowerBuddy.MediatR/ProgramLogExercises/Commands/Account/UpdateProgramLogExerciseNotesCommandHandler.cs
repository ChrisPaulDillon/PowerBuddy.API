using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogExercises.Commands.Account
{
    public class UpdateProgramLogExerciseNotesCommand : IRequest<bool>
    {
        public int ProgramLogExerciseId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateProgramLogExerciseNotesCommand(int programLogExerciseId, string notes, string userId)
        {
            ProgramLogExerciseId = programLogExerciseId;
            Notes = notes;
            UserId = userId;
            new UpdateProgramLogExerciseNotesCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class UpdateProgramLogExerciseNotesCommandValidator : AbstractValidator<UpdateProgramLogExerciseNotesCommand>
    {
        public UpdateProgramLogExerciseNotesCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Notes).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class UpdateProgramLogExerciseNotesCommandHandler : IRequestHandler<UpdateProgramLogExerciseNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogExerciseNotesCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogExerciseNotesCommand request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context.ProgramLogExercise
                .FirstOrDefaultAsync(x => x.ProgramLogExerciseId == request.ProgramLogExerciseId,
                    cancellationToken: cancellationToken);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            var isUserAuthorized = await _context.ProgramLogDay.AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExercise.ProgramLogDayId && x.UserId == request.UserId,
                    cancellationToken: cancellationToken);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            programLogExercise.Comment = request.Notes;

            _context.ProgramLogExercise.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}