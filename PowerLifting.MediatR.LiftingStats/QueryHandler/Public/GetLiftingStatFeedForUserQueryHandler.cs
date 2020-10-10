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
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.LiftingStats.Query.Public;

namespace PowerLifting.MediatR.LiftingStats.QueryHandler.Public
{
    public class GetLiftingStatFeedForUserQueryHandler : IRequestHandler<GetLiftingStatFeedForUserQuery, IEnumerable<LiftFeedDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetLiftingStatFeedForUserQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiftFeedDTO>> Handle(GetLiftingStatFeedForUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            if (user.Id != request.UserId && !user.IsPublic)
            {
                throw new UnauthorisedUserException();
            }

            var liftFeed = await _context.LiftingStatAudit
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .ProjectTo<LiftFeedDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return liftFeed;
        }
    }
}
