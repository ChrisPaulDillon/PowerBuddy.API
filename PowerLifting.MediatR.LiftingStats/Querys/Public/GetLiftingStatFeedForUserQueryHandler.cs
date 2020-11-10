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
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediatR.LiftingStats.Querys.Public
{
    public class GetLiftingStatFeedForUserQuery : IRequest<IEnumerable<LiftFeedDTO>>
    {
        public string UserName { get; }
        public string UserId { get; }

        public GetLiftingStatFeedForUserQuery(string userName, string userId)
        {
            UserName = userName;
            UserId = userId;
        }
    }

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
                .OrderByDescending(x => x.DateChanged)
                .Take(5)
                .ToListAsync(cancellationToken: cancellationToken);

            return liftFeed;
        }
    }
}
