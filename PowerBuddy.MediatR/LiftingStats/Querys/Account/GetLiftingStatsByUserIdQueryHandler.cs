using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.MediatR.LiftingStats.Models;

namespace PowerBuddy.MediatR.LiftingStats.Querys.Account
{
    public class GetLiftingStatsByUserIdQuery : IRequest<IEnumerable<LiftingStatGroupedDTO>>
    {
        public string UserId { get; }

        public GetLiftingStatsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetLiftingStatsByUserIdQueryHandler : IRequestHandler<GetLiftingStatsByUserIdQuery, IEnumerable<LiftingStatGroupedDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLiftingStatsByUserIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiftingStatGroupedDTO>> Handle(GetLiftingStatsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var stats = await _context.LiftingStat.AsNoTracking()
                .Where(u => u.UserId == request.UserId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var groupedStats = stats
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
