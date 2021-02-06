using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Queries.Quotes
{
    public class GetAllQuotesQuery : IRequest<IEnumerable<QuoteDto>>
    {
    }

    public class GetAllQuotesQueryHandler : IRequestHandler<GetAllQuotesQuery, IEnumerable<QuoteDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllQuotesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDto>> Handle(GetAllQuotesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Quote>()
                .Where(x => x.Active)
                .ProjectTo<QuoteDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
