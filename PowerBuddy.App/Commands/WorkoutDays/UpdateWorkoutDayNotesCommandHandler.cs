using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Commands.WorkoutDays
{
    public class UpdateWorkoutDayNotesCommand : IRequest<bool>
    {
        public int WorkoutDayId { get; }
        public string Notes { get; }
        public string UserId { get; }

        public UpdateWorkoutDayNotesCommand(int workoutDayId, string notes, string userId)
        {
            WorkoutDayId = workoutDayId;
            Notes = notes;
            UserId = userId;
        }
    }

    public class UpdateWorkoutDayNotesCommandValidator : AbstractValidator<UpdateWorkoutDayNotesCommand>
    {
        public UpdateWorkoutDayNotesCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Notes).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateWorkoutDayNotesCommandHandler : IRequestHandler<UpdateWorkoutDayNotesCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public UpdateWorkoutDayNotesCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWorkoutDayNotesCommand request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context
                .WorkoutDay
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                return false;
            }

            workoutDay.Comment = request.Notes;

            _context.WorkoutDay.Update(workoutDay);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}