using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PowerBuddy.App.Queries.LiftingStats.Models;
using PowerBuddy.App.Services.LiftingStats;

namespace PowerBuddy.App.Queries.LiftingStats
{
    public class GetLiftingStatsByUserIdQuery : IRequest<IEnumerable<LiftingStatGroupedDTO>>
    {
        public string UserId { get; }

        public GetLiftingStatsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetLiftingStatsByUserIdQueryValidator : AbstractValidator<GetLiftingStatsByUserIdQuery>
    {
        public GetLiftingStatsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetLiftingStatsByUserIdQueryHandler : IRequestHandler<GetLiftingStatsByUserIdQuery, IEnumerable<LiftingStatGroupedDTO>>
    {
        private readonly ILiftingStatService _liftingStatService;

        public GetLiftingStatsByUserIdQueryHandler(ILiftingStatService liftingStatService)
        {
            _liftingStatService = liftingStatService;
        }

        public async Task<IEnumerable<LiftingStatGroupedDTO>> Handle(GetLiftingStatsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var liftingStats = await _liftingStatService.GetTopLiftingStatCollection(request.UserId);

            //var stats = _mapper.Map<IEnumerable<LiftingStatAuditDTO>>(liftingStats);
      
            var groupedStats = liftingStats
                .GroupBy(x => x.ExerciseName)
                .Select(x => new LiftingStatGroupedDTO
                {
                    ExerciseName = x.Key,
                    LiftingStats = x
                })
                .ToList();

            return groupedStats;
        }
    }
}
