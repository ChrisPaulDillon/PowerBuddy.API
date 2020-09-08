using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.System.Query.Public;

namespace PowerLifting.MediatR.System.QueryHandler.Public
{
    public class GetAllMemberStatusQueryHandler : IRequestHandler<GetAllMemberStatusQuery, IEnumerable<MemberStatusDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllMemberStatusQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberStatusDTO>> Handle(GetAllMemberStatusQuery request, CancellationToken cancellationToken)
        {
            return await _context.MemberStatus.AsNoTracking().ProjectTo<MemberStatusDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}