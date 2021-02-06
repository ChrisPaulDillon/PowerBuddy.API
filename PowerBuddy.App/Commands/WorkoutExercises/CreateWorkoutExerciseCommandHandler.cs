using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.App.Services.Workouts.Models;
using PowerBuddy.App.Services.Workouts.Util;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Models.Exercises;
using PowerBuddy.Data.Models.Workouts;

namespace PowerBuddy.App.Commands.WorkoutExercises
{
    public class CreateWorkoutExerciseCommand : IRequest<OneOf<WorkoutExerciseDto, WorkoutDayNotFound, ExerciseNotFound, ReachedMaxSetsOnExercise>>
    {
        public CreateWorkoutExerciseDto CreateWorkoutExerciseDto { get; }
        public string UserId { get; }

        public CreateWorkoutExerciseCommand(CreateWorkoutExerciseDto createWorkoutExerciseDto, string userId)
        {
            CreateWorkoutExerciseDto = createWorkoutExerciseDto;
            UserId = userId;
        }
    }

    public class CreateWorkoutLogExerciseCommandValidator : AbstractValidator<CreateWorkoutExerciseCommand>
    {
        public CreateWorkoutLogExerciseCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.CreateWorkoutExerciseDto.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.CreateWorkoutExerciseDto.Sets).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.CreateWorkoutExerciseDto.Reps).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class CreateWorkoutExerciseCommandHandler : IRequestHandler<CreateWorkoutExerciseCommand, OneOf<WorkoutExerciseDto, WorkoutDayNotFound, ExerciseNotFound, ReachedMaxSetsOnExercise>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;
        private readonly IEntityFactory _entityFactory;

        public CreateWorkoutExerciseCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
            _entityFactory = entityFactory;
        }

        public async Task<OneOf<WorkoutExerciseDto, WorkoutDayNotFound, ExerciseNotFound, ReachedMaxSetsOnExercise>> Handle(CreateWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context.WorkoutDay.FirstOrDefaultAsync(x => x.WorkoutDayId == request.CreateWorkoutExerciseDto.WorkoutDayId);
            if (workoutDay == null)
            {
                return new WorkoutDayNotFound();
            }

            workoutDay.Completed = false; //day is no longer completed if an exercise is added to it

            var exerciseName = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseId == request.CreateWorkoutExerciseDto.ExerciseId)
                .Select(x => x.ExerciseName)
                .FirstOrDefaultAsync();

            if (exerciseName == null || string.IsNullOrWhiteSpace(exerciseName))
            {
                return new ExerciseNotFound();
            }

            var workoutExerciseEntity = await _context.WorkoutExercise
                .AsNoTracking()
                .Include(x => x.WorkoutSets)
                .FirstOrDefaultAsync(x => x.WorkoutDayId == request.CreateWorkoutExerciseDto.WorkoutDayId && 
                                          x.ExerciseId == request.CreateWorkoutExerciseDto.ExerciseId);

            var noOfSetsToAdd = request.CreateWorkoutExerciseDto.Sets;

            if (workoutExerciseEntity == null) //no exercise found for this day, create a fresh one
            {
                workoutExerciseEntity = _workoutService.CreateSetsForExercise(request.CreateWorkoutExerciseDto, request.UserId);
                await _context.WorkoutExercise.AddAsync(workoutExerciseEntity, cancellationToken);
            }
            else //update existing Workout log exercise
            {
                var totalNoOfSets = workoutExerciseEntity.WorkoutSets.Count + noOfSetsToAdd;
                if (totalNoOfSets >= WorkoutConstants.MAX_NO_OF_SETS)
                {
                    return new ReachedMaxSetsOnExercise();
                }

                for (var i = 1; i < noOfSetsToAdd + 1; i++)
                {
                    var workoutSet = _entityFactory.CreateWorkoutSet(workoutExerciseEntity.WorkoutExerciseId, 
                                                                            request.CreateWorkoutExerciseDto.Reps, 
                                                                            request.CreateWorkoutExerciseDto.Weight, 
                                                                            false);
                    workoutExerciseEntity.WorkoutSets.Add(workoutSet);
                }
            }

            await _workoutService.CreateWorkoutExerciseAudit(request.CreateWorkoutExerciseDto.ExerciseId, request.UserId);
            await _context.SaveChangesAsync(cancellationToken);

            var mappedWorkoutLogExercise = _mapper.Map<WorkoutExerciseDto>(workoutExerciseEntity);
            mappedWorkoutLogExercise.ExerciseName = exerciseName;
            return mappedWorkoutLogExercise;
        }
    }
}
