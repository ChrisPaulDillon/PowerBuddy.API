using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Workouts;

namespace PowerBuddy.MediatR.Workouts.Commands
{
    public class DeleteWorkoutLogCommand : IRequest<bool>
    {
        public int WorkoutLogId { get; }
        public string UserId { get; }

        public DeleteWorkoutLogCommand(int programLogId, string userId)
        {
            WorkoutLogId = programLogId;
            UserId = userId;
            new DeleteWorkoutLogCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class DeleteWorkoutLogCommandValidator : AbstractValidator<DeleteWorkoutLogCommand>
    {
        public DeleteWorkoutLogCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }

    internal class DeleteWorkoutLogCommandHandler : IRequestHandler<DeleteWorkoutLogCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DeleteWorkoutLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteWorkoutLogCommand request, CancellationToken cancellationToken)
        {
            var workoutLog = await _context.WorkoutLog.FirstOrDefaultAsync(x => x.WorkoutLogId == request.WorkoutLogId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutLog == null) throw new WorkoutLogNotFoundException();

            _context.WorkoutLog.Remove(workoutLog);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
