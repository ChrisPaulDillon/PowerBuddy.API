using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Exceptions.LiftingStats;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.LiftingStats.Querys.Account
{
    public class GetLiftingStatSummaryByExerciseIdQuery : IRequest<LiftingStatDetailedDTO>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public GetLiftingStatSummaryByExerciseIdQuery(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
            new GetLiftingStatSummaryByExerciseIdQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class GetLiftingStatSummaryByExerciseIdQueryValidator : AbstractValidator<GetLiftingStatSummaryByExerciseIdQuery>
    {
        public GetLiftingStatSummaryByExerciseIdQueryValidator()
        {
            RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetLiftingStatSummaryByExerciseIdQueryHandler : IRequestHandler<GetLiftingStatSummaryByExerciseIdQuery, LiftingStatDetailedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IWorkoutService _workoutService;
        private readonly ILiftingStatService _liftingStatService;

        public GetLiftingStatSummaryByExerciseIdQueryHandler(PowerLiftingContext context, IWorkoutService workoutService, ILiftingStatService liftingStatService)
        {
            _context = context;
            _workoutService = workoutService;
            _liftingStatService = liftingStatService;
        }

        public async Task<LiftingStatDetailedDTO> Handle(GetLiftingStatSummaryByExerciseIdQuery request, CancellationToken cancellationToken)
        {
            var liftingStats = await _liftingStatService.GetTopLiftingStatForExercise(request.ExerciseId, request.UserId);

            if (liftingStats == null)
            {
                throw new LiftingStatNotFoundException();
            }

            var lifetimeTonnage = await _workoutService.CalculateLifetimeTonnageForExercise(request.ExerciseId, request.UserId);

            var exerciseName = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseId == request.ExerciseId)
                .Select(x => x.ExerciseName)
                .FirstOrDefaultAsync();

            var liftingStatDetailed = new LiftingStatDetailedDTO()
            {
                ExerciseName = exerciseName,
                LifeTimeTonnage = lifetimeTonnage,
                LiftingStats = liftingStats,
            };

            return liftingStatDetailed;
        }
    }
}
