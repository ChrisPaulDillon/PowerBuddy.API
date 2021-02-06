using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Services.LiftingStats;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Models.LiftingStats;

namespace PowerBuddy.App.Queries.LiftingStats
{
    public class GetLiftingStatSummaryByExerciseIdQuery : IRequest<OneOf<LiftingStatDetailedDto, LiftingStatNotFound>>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public GetLiftingStatSummaryByExerciseIdQuery(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
        }
    }

    public class GetLiftingStatSummaryByExerciseIdQueryValidator : AbstractValidator<GetLiftingStatSummaryByExerciseIdQuery>
    {
        public GetLiftingStatSummaryByExerciseIdQueryValidator()
        {
            RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetLiftingStatSummaryByExerciseIdQueryHandler : IRequestHandler<GetLiftingStatSummaryByExerciseIdQuery, OneOf<LiftingStatDetailedDto, LiftingStatNotFound>>
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

        public async Task<OneOf<LiftingStatDetailedDto, LiftingStatNotFound>> Handle(GetLiftingStatSummaryByExerciseIdQuery request, CancellationToken cancellationToken)
        {
            var liftingStats = await _liftingStatService.GetTopLiftingStatForExercise(request.ExerciseId, request.UserId);

            if (liftingStats == null)
            {
                return new LiftingStatNotFound();
            }

            var lifetimeTonnage = await _workoutService.CalculateLifetimeTonnageForExercise(request.ExerciseId, request.UserId);

            var exerciseName = await _context.Exercise
                .AsNoTracking()
                .Where(x => x.ExerciseId == request.ExerciseId)
                .Select(x => x.ExerciseName)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var liftingStatDetailed = new LiftingStatDetailedDto()
            {
                ExerciseName = exerciseName,
                LifeTimeTonnage = lifetimeTonnage,
                LiftingStats = liftingStats,
            };

            return liftingStatDetailed;
        }
    }
}
