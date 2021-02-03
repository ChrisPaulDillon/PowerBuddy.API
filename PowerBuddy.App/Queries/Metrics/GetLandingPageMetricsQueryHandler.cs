using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.App.Queries.Metrics.Models;
using PowerBuddy.App.Services.Account;
using PowerBuddy.App.Services.Workouts;

namespace PowerBuddy.App.Queries.Metrics
{
    public class GetLandingPageMetricsQuery : IRequest<LandingPageMetrics>
    {
    }

    public class GetLandingPageMetricsQueryHandler : IRequestHandler<GetLandingPageMetricsQuery, LandingPageMetrics>
    {
        private readonly IWorkoutService _workoutService;
        private readonly IAccountService _accountService;

        public GetLandingPageMetricsQueryHandler(IWorkoutService workoutService, IAccountService accountService)
        {
            _workoutService = workoutService;
            _accountService = accountService;
        }

        public async Task<LandingPageMetrics> Handle(GetLandingPageMetricsQuery request, CancellationToken cancellationToken)
        {
            var setCount = await _workoutService.GetTotalWorkoutSetsCount();
            var userCount = await _accountService.GetTotalUserCount();

            var landingMetrics = new LandingPageMetrics()
            {
                SetCount = setCount,
                UserCount = userCount
            };

            return landingMetrics;
        }
    }
}
