using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PowerBuddy.MediatR.Metrics.Models;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.Metrics.Querys
{
    public class GetLandingPageMetricsQuery : IRequest<LandingPageMetrics>
    {

        public GetLandingPageMetricsQuery()
        {
        }
    }

    public class GetLandingPageMetricsQueryHandler : IRequestHandler<GetLandingPageMetricsQuery, LandingPageMetrics>
    {
        private readonly IProgramLogService _programLogService;
        private readonly IAccountService _accountService;

        public GetLandingPageMetricsQueryHandler(IProgramLogService programLogService, IAccountService accountService)
        {
            _programLogService = programLogService;
            _accountService = accountService;
        }

        public async Task<LandingPageMetrics> Handle(GetLandingPageMetricsQuery request, CancellationToken cancellationToken)
        {
            var setCount = await _programLogService.GetTotalRepSchemeCount();
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
