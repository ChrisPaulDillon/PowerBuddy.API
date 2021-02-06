using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Commands.WorkoutExercises
{
    public class UpdateWorkoutExerciseNoteCommand : IRequest<bool>
    {
        public int WorkoutExerciseId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateWorkoutExerciseNoteCommand(int workoutExerciseId, string notes, string userId)
        {
            WorkoutExerciseId = workoutExerciseId;
            Notes = notes;
            UserId = userId;
        }
    }

    public class UpdateWorkoutExerciseNotesCommandValidator : AbstractValidator<UpdateWorkoutExerciseNoteCommand>
    {
        public UpdateWorkoutExerciseNotesCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Notes).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateWorkoutExerciseNotesCommandHandler : IRequestHandler<UpdateWorkoutExerciseNoteCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public UpdateWorkoutExerciseNotesCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWorkoutExerciseNoteCommand request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context
                .WorkoutExercise
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutExerciseId);

            if (programLogExercise == null) return false;

            var isUserAuthorized = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutDayId == programLogExercise.WorkoutDayId && x.UserId == request.UserId);

            if (!isUserAuthorized) return false;

            programLogExercise.Comment = request.Notes;

            _context.WorkoutExercise.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}