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
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.LiftingStats.Query.Account;

namespace PowerLifting.MediatR.LiftingStats.QueryHandler.Account
{
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
            return await _context.Set<LiftingStat>().Where(u => u.UserId == request.UserId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
