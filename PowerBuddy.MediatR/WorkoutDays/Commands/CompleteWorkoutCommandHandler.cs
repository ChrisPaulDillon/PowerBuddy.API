using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.WorkoutDays.Commands
{
    public class CompleteWorkoutCommand : IRequest<IEnumerable<LiftingStatAuditDTO>>
    {
        public WorkoutDayDTO WorkoutDayDTO { get; }
        public string UserId { get; }

        public CompleteWorkoutCommand(WorkoutDayDTO workoutDayDTO, string userId)
        {
            WorkoutDayDTO = workoutDayDTO;
            UserId = userId;
            new CompleteWorkoutMemberCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CompleteWorkoutMemberCommandValidator : AbstractValidator<CompleteWorkoutCommand>
    {
        public CompleteWorkoutMemberCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayDTO.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class CompleteWorkoutCommandHandler : IRequestHandler<CompleteWorkoutCommand, IEnumerable<LiftingStatAuditDTO>>
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

        public async Task<IEnumerable<LiftingStatAuditDTO>> Handle(CompleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context.WorkoutDay.AsNoTracking()
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.WorkoutDayDTO.WorkoutDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                throw new WorkoutDayNotFoundException();
            }

            var workoutExercises = request.WorkoutDayDTO.WorkoutExercises.ToList();

            var totalPersonalBests = new List<LiftingStatAuditDTO>();
  
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
                        request.WorkoutDayDTO.Date,
                        request.UserId);

                    //_context.LiftingStatAudit.Add(hitPersonalBest);

                    //hitPersonalBest.Exercise = await _context.Exercise.AsNoTracking().FirstOrDefaultAsync(x => x.ExerciseId == workoutExercise.ExerciseId);
                    totalPersonalBests.Add(_mapper.Map<LiftingStatAuditDTO>(hitPersonalBest));
                    //_context.Entry(hitPersonalBest.Exercise).State = EntityState.Detached;

    
                    workoutSet.NoOfReps = (int)workoutSet.RepsCompleted;
                    var setEntity = _mapper.Map<WorkoutSet>(workoutSet);
                    hitPersonalBest.WorkoutSet = setEntity;
                    //setEntity.LiftingStatAudit = hitPersonalBest;
                    //setEntity.LiftingStatAuditId = hitPersonalBest.LiftingStatAuditId;
                    _context.LiftingStatAudit.Add(hitPersonalBest);

                    // workoutSet.LiftingStatAuditId = hitPersonalBest.LiftingStatAuditId;

                    //var index = updateWorkoutSets.FindIndex(a => a.WorkoutSetId == workoutSet.WorkoutSetId);
                    //updateWorkoutSets[index] = workoutSet; //replace the current program log rep scheme with the newly updated PB
                }
            }

            workoutDay.Completed = true;
            await _context.SaveChangesAsync(cancellationToken);

            return totalPersonalBests;
        }
    }
}