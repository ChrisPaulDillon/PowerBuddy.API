using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.App.Services.LiftingStats;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Models.Workouts;

namespace PowerBuddy.App.Commands.WorkoutDays
{
    public class CompleteWorkoutCommand : IRequest<OneOf<IEnumerable<LiftingStatAuditDto>, WorkoutDayNotFound>>
    {
        public WorkoutDayDto WorkoutDayDto { get; }
        public string UserId { get; }

        public CompleteWorkoutCommand(WorkoutDayDto workoutDayDto, string userId)
        {
            WorkoutDayDto = workoutDayDto;
            UserId = userId;
        }
    }

    public class CompleteWorkoutCommandValidator : AbstractValidator<CompleteWorkoutCommand>
    {
        public CompleteWorkoutCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayDto).NotNull().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayDto.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayDto.WorkoutDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutDayDto.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutDayDto.WorkoutExercises).ValidWorkoutExerciseCollection().WithMessage("'{PropertyName}' must be valid");
        }
    }

    public class CompleteWorkoutCommandHandler : IRequestHandler<CompleteWorkoutCommand, OneOf<IEnumerable<LiftingStatAuditDto>, WorkoutDayNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;
        private readonly ILiftingStatService _liftingStatService;
        private readonly IEntityFactory _entityFactory;

        public CompleteWorkoutCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService, ILiftingStatService liftingStatService, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
            _liftingStatService = liftingStatService;
            _entityFactory = entityFactory;
        }

        public async Task<OneOf<IEnumerable<LiftingStatAuditDto>, WorkoutDayNotFound>> Handle(CompleteWorkoutCommand request, CancellationToken cancellationToken)
        {
	        var workoutDay = await _context.WorkoutDay
		        .AsNoTracking()
		        .Where(x => x.WorkoutDayId == request.WorkoutDayDto.WorkoutDayId && x.UserId == request.UserId)
		        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                return new WorkoutDayNotFound();
            }

            var totalPersonalBests = new List<LiftingStatAuditDto>();

            foreach (var workoutExercise in request.WorkoutDayDto.WorkoutExercises.ToList())
            {
                //Get the highest weight lifted for the given exercise and each rep
                var maxWeightForEachRepRange = _workoutService.GetHighestWeightRepSchemeForEachRepFromCollection(workoutExercise.WorkoutSets);
                var repRangesForExercise = maxWeightForEachRepRange.Select(x => (int)x.RepsCompleted).ToList();
                var personalBestsOnExercise = await _liftingStatService.GetPersonalBestsForRepRangeAndExercise(repRangesForExercise, workoutExercise.ExerciseId, request.UserId);

                foreach (var workoutSet in maxWeightForEachRepRange.Where(repScheme => repScheme.RepsCompleted != 0))
                {
	                if (personalBestsOnExercise.TryGetValue((int)workoutSet.RepsCompleted, out var personalBest)) //Personal best exists
                    {
                        if (workoutSet.WeightLifted <= personalBest.Weight)
                        {
                            continue; //Personal best was higher than max weight
                        }
                    }

                    var hitPersonalBest = _entityFactory.CreateLiftingStatAudit(
                        workoutExercise.ExerciseId,
                        (int)workoutSet.RepsCompleted,
                        workoutSet.WeightLifted,
                        request.WorkoutDayDto.Date,
                        request.UserId);

                    hitPersonalBest.WorkoutSetId = workoutSet.WorkoutSetId;
                    workoutSet.NoOfReps = (int)workoutSet.RepsCompleted;

                    var workoutSetEntity = _mapper.Map<WorkoutSet>(workoutSet);
                    workoutSetEntity.LiftingStatAuditId = hitPersonalBest.LiftingStatAuditId;
                    _context.WorkoutSet.Update(workoutSetEntity);

                    await _context.LiftingStatAudit.AddAsync(hitPersonalBest, cancellationToken);

                    hitPersonalBest.Exercise = await _context.Exercise.AsNoTracking().FirstOrDefaultAsync(x => x.ExerciseId == workoutExercise.ExerciseId, cancellationToken: cancellationToken);
                    totalPersonalBests.Add(_mapper.Map<LiftingStatAuditDto>(hitPersonalBest));

                    if (hitPersonalBest.Exercise != null)
                    {
	                    _context.Entry(hitPersonalBest.Exercise).State = EntityState.Detached;
                    }
                }
            }

            workoutDay.Completed = true;
            await _context.SaveChangesAsync(cancellationToken);

            return totalPersonalBests;
        }
    }
}