using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.MediatR.WorkoutExercises.Commands
{
    public class DeleteWorkoutExerciseCommand : IRequest<bool>
    {
        public int WorkoutExerciseId { get; }
        public string UserId { get; }

        public DeleteWorkoutExerciseCommand(int workoutExerciseId, string userId)
        {
            WorkoutExerciseId = workoutExerciseId;
            UserId = userId;
        }
    }

    public class DeleteWorkoutExerciseCommandValidator : AbstractValidator<DeleteWorkoutExerciseCommand>
    {
        public DeleteWorkoutExerciseCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class DeleteWorkoutExerciseCommandHandler : IRequestHandler<DeleteWorkoutExerciseCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DeleteWorkoutExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutExercise = await _context.WorkoutExercise
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutExerciseId, cancellationToken: cancellationToken);

            if (workoutExercise == null) return false;

            var isUserAuthorized = await _context.WorkoutDay
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!isUserAuthorized) return false;

            _context.WorkoutExercise.Remove(workoutExercise);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
