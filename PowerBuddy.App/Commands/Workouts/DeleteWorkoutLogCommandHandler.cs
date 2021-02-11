using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Workouts
{
    public class DeleteWorkoutLogCommand : IRequest<OneOf<bool, WorkoutLogNotFound>>
    {
        public int WorkoutLogId { get; }
        public string UserId { get; }

        public DeleteWorkoutLogCommand(int workoutLogId, string userId)
        {
            WorkoutLogId = workoutLogId;
            UserId = userId;
        }
    }

    public class DeleteWorkoutLogCommandValidator : AbstractValidator<DeleteWorkoutLogCommand>
    {
        public DeleteWorkoutLogCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutLogId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class DeleteWorkoutLogCommandHandler : IRequestHandler<DeleteWorkoutLogCommand, OneOf<bool, WorkoutLogNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public DeleteWorkoutLogCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, WorkoutLogNotFound>> Handle(DeleteWorkoutLogCommand request, CancellationToken cancellationToken)
        {
            var workoutLog = await _context.WorkoutLog
                .FirstOrDefaultAsync(x => x.WorkoutLogId == request.WorkoutLogId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutLog == null)
            {
                return new WorkoutLogNotFound();
            }

            _context.WorkoutLog.Remove(workoutLog);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
