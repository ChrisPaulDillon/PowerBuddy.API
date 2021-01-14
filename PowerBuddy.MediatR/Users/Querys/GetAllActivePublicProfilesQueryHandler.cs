using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.MediatR.Users.Querys
{
    public class GetAllActivePublicProfilesQuery : IRequest<IEnumerable<PublicUserDTO>>
    {
        public string UserId { get; }
        public GetAllActivePublicProfilesQuery(string userId)
        {
            UserId = userId;
        }
    }

    internal class GetAllActivePublicProfilesQueryHandler : IRequestHandler<GetAllActivePublicProfilesQuery, IEnumerable<PublicUserDTO>>
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
