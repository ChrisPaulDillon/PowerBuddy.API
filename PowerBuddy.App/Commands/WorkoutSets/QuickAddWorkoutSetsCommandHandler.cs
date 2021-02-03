using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.s.Workouts;

namespace PowerBuddy.App.Commands.WorkoutSets
{
    public class QuickAddWorkoutSetsCommand : IRequest<IEnumerable<WorkoutSetDTO>>
    {
        public IList<WorkoutSetDTO> WorkoutSetList { get; }
        public string UserId { get; }

        public QuickAddWorkoutSetsCommand(IList<WorkoutSetDTO> workoutSetList, string userId)
        {
            WorkoutSetList = workoutSetList;
            UserId = userId;
        }
    }

    public class QuickAddWorkoutSetsCommandValidator : AbstractValidator<QuickAddWorkoutSetsCommand>
    {
        public QuickAddWorkoutSetsCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutSetList.Count).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class QuickAddWorkoutSetsCommandHandler : IRequestHandler<QuickAddWorkoutSetsCommand, IEnumerable<WorkoutSetDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public QuickAddWorkoutSetsCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkoutSetDTO>> Handle(QuickAddWorkoutSetsCommand request, CancellationToken cancellationToken)
        {
            var workoutExercise = await _context.WorkoutExercise
                .Include(x => x.WorkoutSets)
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutSetList[0].WorkoutExerciseId);

            if (workoutExercise == null) return new WorkoutExerciseNotFound();

            var workoutDay = await _context.WorkoutDay
                .FirstOrDefaultAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId);

            if (workoutDay == null)
            {
                return new WorkoutDayNotFound();
            }

            workoutDay.Completed = false;
            
            var workoutSetCollection = _mapper.Map<IEnumerable<WorkoutSet>>(request.WorkoutSetList);
            //var workoutExerciseTonnage = await _workoutService.UpdateExerciseTonnage(workoutExercise, request.UserId);
            //workoutExercise.WorkoutExerciseTonnage = workoutExerciseTonnage;

            _context.WorkoutSet.AddRange(workoutSetCollection);
            await _context.SaveChangesAsync(cancellationToken);

            var workoutSets =  _mapper.Map<IEnumerable<WorkoutSetDTO>>(workoutSetCollection);
            return workoutSets;
        }
    }
}
