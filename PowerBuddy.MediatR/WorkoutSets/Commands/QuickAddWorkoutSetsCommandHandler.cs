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
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.WorkoutSets.Commands
{
    public class QuickAddWorkoutSetsCommand : IRequest<IEnumerable<WorkoutSetDTO>>
    {
        public IList<WorkoutSetDTO> WorkoutSetList { get; }
        public string UserId { get; }

        public QuickAddWorkoutSetsCommand(IList<WorkoutSetDTO> workoutSetList, string userId)
        {
            WorkoutSetList = workoutSetList;
            UserId = userId;
            new QuickAddWorkoutSetsCommandValidator().ValidateAndThrow(this);
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
        private readonly IWorkoutService _workoutService;
        private readonly IMapper _mapper;

        public QuickAddWorkoutSetsCommandHandler(PowerLiftingContext context, IWorkoutService workoutService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
        }

        public async Task<IEnumerable<WorkoutSetDTO>> Handle(QuickAddWorkoutSetsCommand request, CancellationToken cancellationToken)
        {
            var workoutExercise = await _context.WorkoutExercise
                .Include(x => x.WorkoutSets)
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutSetList[0].WorkoutExerciseId);

            if (workoutExercise == null) throw new WorkoutExerciseNotFoundException();

            var workoutDay = await _context.WorkoutDay
                .FirstOrDefaultAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId);

            if (workoutDay == null) throw new UnauthorisedUserException();

            workoutDay.Completed = false;

            var workoutSetCollection = _mapper.Map<IEnumerable<WorkoutSet>>(request.WorkoutSetList);

            var workoutExerciseTonnage = await _workoutService.UpdateExerciseTonnage(workoutExercise, request.UserId);
            workoutExercise.WorkoutExerciseTonnage = workoutExerciseTonnage;

            _context.WorkoutSet.AddRange(workoutSetCollection);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<WorkoutSetDTO>>(workoutSetCollection);
        }
    }
}
