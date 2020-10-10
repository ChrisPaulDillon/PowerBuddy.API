﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.MediaR.Quotes.Query.Public;

namespace PowerLifting.MediaR.Quotes.QueryHandler.Public
{
    public class GetAllQuotesQueryHandler : IRequestHandler<GetAllQuotesQuery, IEnumerable<QuoteDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllQuotesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDTO>> Handle(GetAllQuotesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Quote>()
                .Where(x => x.Active)
                .ProjectTo<QuoteDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
