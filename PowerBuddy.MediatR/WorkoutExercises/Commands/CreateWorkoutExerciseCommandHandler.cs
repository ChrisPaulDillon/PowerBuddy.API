using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Weights;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Services.Workouts.Models;
using PowerBuddy.Services.Workouts.Util;

namespace PowerBuddy.MediatR.WorkoutExercises.Commands
{
    public class CreateWorkoutExerciseCommand : IRequest<WorkoutExerciseDTO>
    {
        public CreateWorkoutExerciseDTO CreateWorkoutExerciseDTO { get; }
        public string UserId { get; }

        public CreateWorkoutExerciseCommand(CreateWorkoutExerciseDTO createWorkoutExerciseDTO, string userId)
        {
            CreateWorkoutExerciseDTO = createWorkoutExerciseDTO;
            UserId = userId;
            new CreateWorkoutLogExerciseCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class CreateWorkoutLogExerciseCommandValidator : AbstractValidator<CreateWorkoutExerciseCommand>
    {
        public CreateWorkoutLogExerciseCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.CreateWorkoutExerciseDTO.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.CreateWorkoutExerciseDTO.Sets).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.CreateWorkoutExerciseDTO.Reps).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class CreateWorkoutExerciseCommandHandler : IRequestHandler<CreateWorkoutExerciseCommand, WorkoutExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IWorkoutService _workoutService;
        private readonly IEntityFactory _entityFactory;
        private readonly IWeightService _weightService;

        public CreateWorkoutExerciseCommandHandler(PowerLiftingContext context, IMapper mapper, IAccountService accountService, IWorkoutService workoutService, IEntityFactory entityFactory, IWeightService weightService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
            _workoutService = workoutService;
            _entityFactory = entityFactory;
            _weightService = weightService;
        }

        public async Task<WorkoutExerciseDTO> Handle(CreateWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context.WorkoutDay.FirstOrDefaultAsync(x => x.WorkoutDayId == request.CreateWorkoutExerciseDTO.WorkoutDayId);
            if (workoutDay == null) throw new WorkoutDayNotFoundException();

            workoutDay.Completed = false; //day is no longer completed if an exercise is added to it

            var exerciseName = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseId == request.CreateWorkoutExerciseDTO.ExerciseId)
                .Select(x => x.ExerciseName)
                .FirstOrDefaultAsync();

            if (exerciseName == null || string.IsNullOrWhiteSpace(exerciseName))
            {
                throw new ExerciseNotFoundException();
            }

            var workoutExerciseEntity = await _context.WorkoutExercise
                .AsNoTracking()
                .Include(x => x.WorkoutSets)
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.CreateWorkoutExerciseDTO.WorkoutDayId && 
                                          x.ExerciseId == request.CreateWorkoutExerciseDTO.ExerciseId);

            var noOfSetsToAdd = request.CreateWorkoutExerciseDTO.Sets;

            var isMetric = await _accountService.IsUserUsingMetric(request.UserId);

            if (workoutExerciseEntity == null) //no exercise found for this day, create a fresh one
            {
                workoutExerciseEntity = _workoutService.CreateSetsForExercise(request.CreateWorkoutExerciseDTO, request.UserId, isMetric);
                _context.WorkoutExercise.Add(workoutExerciseEntity);
            }
            else //update existing Workout log exercise
            {
                var totalNoOfSets = workoutExerciseEntity.WorkoutSets.Count() + noOfSetsToAdd;
                if (totalNoOfSets >= WorkoutConstants.MAX_NO_OF_SETS)
                {
                    throw new ReachedMaxSetsOnExerciseException();
                }

                for (var i = 1; i < noOfSetsToAdd + 1; i++)
                {
                    var workoutSet = _entityFactory.CreateWorkoutSet(workoutExerciseEntity.WorkoutExerciseId, 
                                                                            request.CreateWorkoutExerciseDTO.Reps, 
                                                                            request.CreateWorkoutExerciseDTO.Weight, 
                                                                            false);

                    workoutSet = _weightService.ConvertInsertWeightSetToDbSuitable(isMetric, workoutSet);
                    workoutExerciseEntity.WorkoutSets.Add(workoutSet);
                }
            }

            await _workoutService.CreateWorkoutExerciseAudit(request.CreateWorkoutExerciseDTO.ExerciseId, request.UserId);
            await _context.SaveChangesAsync(cancellationToken);

            var mappedWorkoutLogExercise = _mapper.Map<WorkoutExerciseDTO>(workoutExerciseEntity);
            mappedWorkoutLogExercise.ExerciseName = exerciseName;

            mappedWorkoutLogExercise.WorkoutSets = _weightService.ConvertReturnedWorkoutSets(isMetric, mappedWorkoutLogExercise.WorkoutSets);
            return mappedWorkoutLogExercise;
        }
    }
}
