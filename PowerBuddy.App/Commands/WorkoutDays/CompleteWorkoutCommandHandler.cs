﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
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

    public class CompleteWorkoutMemberCommandValidator : AbstractValidator<CompleteWorkoutCommand>
    {
        public CompleteWorkoutMemberCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayDto.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
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
            var workoutDay = await _context.WorkoutDay.AsNoTracking()
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.WorkoutDayDto.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                return new WorkoutDayNotFound();
            }

            var workoutExercises = request.WorkoutDayDto.WorkoutExercises.ToList();

            var totalPersonalBests = new List<LiftingStatAuditDto>();

            foreach (var workoutExercise in workoutExercises)
            {
                //Get the highest weight lifted for the given exercise and each rep
                var maxWeightForEachSet = _workoutService.GetHighestWeightRepSchemeForEachRepFromCollection(workoutExercise.WorkoutSets);
                var repRangesForExercise = maxWeightForEachSet.Select(x => (int)x.RepsCompleted).ToList();
                var personalBestsOnExercise = await _liftingStatService.GetPersonalBestsForRepRangeAndExercise(repRangesForExercise, workoutExercise.ExerciseId, request.UserId);

                var personalBest = new LiftingStatAudit();
                foreach (var workoutSet in maxWeightForEachSet.Where(repScheme => repScheme.RepsCompleted != 0))
                {

                    if (personalBestsOnExercise.TryGetValue(Tuple.Create(workoutExercise.ExerciseId, (int)workoutSet.RepsCompleted), out personalBest)) //Personal best exists
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

                    await _context.LiftingStatAudit.AddAsync(hitPersonalBest, cancellationToken);

                    hitPersonalBest.Exercise = await _context.Exercise.AsNoTracking().FirstOrDefaultAsync(x => x.ExerciseId == workoutExercise.ExerciseId, cancellationToken: cancellationToken);
                    totalPersonalBests.Add(_mapper.Map<LiftingStatAuditDto>(hitPersonalBest));
                    _context.Entry(hitPersonalBest.Exercise).State = EntityState.Detached;

                    workoutSet.NoOfReps = (int)workoutSet.RepsCompleted;
                    var setEntity = _mapper.Map<WorkoutSet>(workoutSet);
                    hitPersonalBest.WorkoutSet = setEntity;
                }
            }

            workoutDay.Completed = true;
            await _context.SaveChangesAsync(cancellationToken);

            return totalPersonalBests;
        }
    }
}