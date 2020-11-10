using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Querys.Account
{
    public class GetLiftingStatsByUserIdQuery : IRequest<IEnumerable<LiftingStatDTO>>
    {
        public string UserId { get; }

        public GetLiftingStatsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetLiftingStatsByUserIdQueryHandler : IRequestHandler<GetLiftingStatsByUserIdQuery, IEnumerable<LiftingStatDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLiftingStatsByUserIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiftingStatDTO>> Handle(GetLiftingStatsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.LiftingStat.Where(u => u.UserId == request.UserId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
