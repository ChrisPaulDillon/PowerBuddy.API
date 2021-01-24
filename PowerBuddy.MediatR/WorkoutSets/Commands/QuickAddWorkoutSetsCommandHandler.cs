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
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Weights;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Services.Workouts.Util;

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

    internal class QuickAddWorkoutSetsCommandValidator : AbstractValidator<QuickAddWorkoutSetsCommand>
    {
        public QuickAddWorkoutSetsCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutSetList.Count).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class QuickAddWorkoutSetsCommandHandler : IRequestHandler<QuickAddWorkoutSetsCommand, IEnumerable<WorkoutSetDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IWeightService _weightService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public QuickAddWorkoutSetsCommandHandler(PowerLiftingContext context, IWeightService weightService, IAccountService accountService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _weightService = weightService;
            _accountService = accountService;
        }

        public async Task<IEnumerable<WorkoutSetDTO>> Handle(QuickAddWorkoutSetsCommand request, CancellationToken cancellationToken)
        {
            var isMetric = await _accountService.IsUserUsingMetric(request.UserId);

            var workoutExercise = await _context.WorkoutExercise
                .Include(x => x.WorkoutSets)
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == request.WorkoutSetList[0].WorkoutExerciseId);

            if (workoutExercise == null) throw new WorkoutExerciseNotFoundException();

            var workoutDay = await _context.WorkoutDay
                .FirstOrDefaultAsync(x => x.WorkoutDayId == workoutExercise.WorkoutDayId && x.UserId == request.UserId);

            if (workoutDay == null)
            {
                throw new WorkoutDayNotFoundException();
            }

            workoutDay.Completed = false;
            
            var workoutSetCollection = _mapper.Map<IEnumerable<WorkoutSet>>(request.WorkoutSetList);
            workoutSetCollection = _weightService.ConvertInsertWeightSetsToDbSuitable(isMetric, workoutSetCollection);
            //var workoutExerciseTonnage = await _workoutService.UpdateExerciseTonnage(workoutExercise, request.UserId);
            //workoutExercise.WorkoutExerciseTonnage = workoutExerciseTonnage;

            _context.WorkoutSet.AddRange(workoutSetCollection);
            await _context.SaveChangesAsync(cancellationToken);

            var workoutSets =  _mapper.Map<IEnumerable<WorkoutSetDTO>>(workoutSetCollection);
            workoutSets = _weightService.ConvertReturnedWorkoutSets(isMetric, workoutSets);

            return workoutSets;
        }
    }
}
