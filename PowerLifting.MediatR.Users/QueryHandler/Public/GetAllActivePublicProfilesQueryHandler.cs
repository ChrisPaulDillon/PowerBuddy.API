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
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Query.Public;

namespace PowerLifting.MediatR.Users.QueryHandler.Public
{
    public class GetAllActivePublicProfilesQueryHandler : IRequestHandler<GetAllActivePublicProfilesQuery, IEnumerable<PublicUserDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllActivePublicProfilesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublicUserDTO>> Handle(GetAllActivePublicProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.Where(x => x.IsPublic && x.Id != request.UserId)
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
