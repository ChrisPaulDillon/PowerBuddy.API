using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Commands.WorkoutExercises
{
    public class UpdateWorkoutExerciseNotesCommand : IRequest<bool>
    {
        public int WorkoutExerciseId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateWorkoutExerciseNotesCommand(int workoutExerciseId, string notes, string userId)
        {
            WorkoutExerciseId = workoutExerciseId;
            Notes = notes;
            UserId = userId;
        }
    }

    public class UpdateWorkoutExerciseNotesCommandValidator : AbstractValidator<UpdateWorkoutExerciseNotesCommand>
    {
        public UpdateWorkoutExerciseNotesCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Notes).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateWorkoutExerciseNotesCommandHandler : IRequestHandler<UpdateWorkoutExerciseNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public UpdateWorkoutExerciseNotesCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWorkoutExerciseNotesCommand request, CancellationToken cancellationToken)
        {
            var workoutExercise = await _context
                .WorkoutExercise
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutExerciseId, cancellationToken: cancellationToken);

            if (workoutExercise == null)
            {
                return false;
            }

            var isUserAuthorized = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized)
            {
                return false;
            }

            workoutExercise.Comment = request.Notes;

            _context.WorkoutExercise.Update(workoutExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}