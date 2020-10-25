using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Query.Account;

namespace PowerLifting.MediatR.LiftingStats.QueryHandler.Account
{
    public class GetLiftingStatByIdQueryHandler : IRequestHandler<GetLiftingStatByIdQuery, LiftingStatDetailedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLiftingStatByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LiftingStatDetailedDTO> Handle(GetLiftingStatByIdQuery request, CancellationToken cancellationToken)
        {
            var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.LiftingStatId == request.LiftingStatId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            var liftFeed = await _context.LiftingStatAudit.Where(x => x.UserId == request.UserId && x.LiftingStatId == request.LiftingStatId)
                .ProjectTo<LiftFeedDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            if (liftingStats == null) throw new LiftingStatNotFoundException();

            var liftingStatDetailed = new LiftingStatDetailedDTO()
            {
                LiftingStats = liftingStats,
                LiftFeed = liftFeed
            };

            return liftingStatDetailed;
        }
    }
}
