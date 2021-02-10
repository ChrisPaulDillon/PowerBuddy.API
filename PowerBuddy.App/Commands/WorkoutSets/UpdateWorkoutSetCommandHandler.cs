using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Account;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Commands.WorkoutSets
{
    public class UpdateWorkoutSetCommand : IRequest<bool>
    {
        public int WorkoutDayId { get; }
        public WorkoutSetDto WorkoutSetDto { get; }
        public string UserId { get; }

        public UpdateWorkoutSetCommand(int workoutDayId, WorkoutSetDto workoutSetDto, string userId)
        {
            WorkoutDayId = workoutDayId;
            WorkoutSetDto = workoutSetDto;
            UserId = userId;
        }
    }

    public class UpdateWorkoutSetCommandValidator : AbstractValidator<UpdateWorkoutSetCommand>
    {
        public UpdateWorkoutSetCommandValidator()
        {
            RuleFor(x => x.WorkoutSetDto.WorkoutSetId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutSetDto.WorkoutExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutSetDto.NoOfReps).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutSetDto.RepsCompleted).GreaterThan(-1).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutSetDto.WeightLifted).GreaterThan(-1).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class UpdateWorkoutSetCommandHandler : IRequestHandler<UpdateWorkoutSetCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;

        public UpdateWorkoutSetCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService, IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
        }

        public async Task<bool> Handle(UpdateWorkoutSetCommand request, CancellationToken cancellationToken)
        {
            var doesSetExist = await _context.WorkoutSet
                .AsNoTracking()
                .AnyAsync(x => x.WorkoutSetId == request.WorkoutSetDto.WorkoutSetId, cancellationToken: cancellationToken);

            if (!doesSetExist) return false;

            var workoutDay = await _context.WorkoutDay
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                return false;
            }

            workoutDay.Completed = false;

            var workoutSet = _mapper.Map<WorkoutSet>(request.WorkoutSetDto);

            _context.WorkoutSet.Update(workoutSet);

            await _context.SaveChangesAsync(cancellationToken);

            var workoutExerciseTonnageUpdate = await _context.WorkoutExercise
                .AsNoTracking()
                .Include(x => x.WorkoutSets)
                .Include(x => x.WorkoutExerciseTonnage)
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutSetDto.WorkoutExerciseId, cancellationToken: cancellationToken);

            workoutExerciseTonnageUpdate.WorkoutExerciseTonnage = await _workoutService.UpdateExerciseTonnage(workoutExerciseTonnageUpdate, request.UserId);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}
