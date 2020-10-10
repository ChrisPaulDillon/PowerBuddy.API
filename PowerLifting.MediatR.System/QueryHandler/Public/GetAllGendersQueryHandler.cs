using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.System.Query.Public;

namespace PowerLifting.MediatR.System.QueryHandler.Public
{
    public class GetAllGendersQueryHandler : IRequestHandler<GetAllGendersQuery, IEnumerable<GenderDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllGendersQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenderDTO>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Gender.AsNoTracking().ProjectTo<GenderDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}