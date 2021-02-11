using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.LiftingStats
{
    public class GetLiftingStatFeedForUserQuery : IRequest<OneOf<IEnumerable<LiftFeedDto>, UserNotFound>>
    {
        public string UserName { get; }
        public string UserId { get; }

        public GetLiftingStatFeedForUserQuery(string userName, string userId)
        {
            UserName = userName;
            UserId = userId;
        }
    }

    public class GetLiftingStatFeedForUserQueryValidator : AbstractValidator<GetLiftingStatFeedForUserQuery>
    {
        public GetLiftingStatFeedForUserQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    internal class GetLiftingStatFeedForUserQueryHandler : IRequestHandler<GetLiftingStatFeedForUserQuery, OneOf<IEnumerable<LiftFeedDto>, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetLiftingStatFeedForUserQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<IEnumerable<LiftFeedDto>, UserNotFound>> Handle(GetLiftingStatFeedForUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            if (user.Id != request.UserId && !user.IsPublic)
            {
                return new UserNotFound();
            }

            var liftFeed = await _context.LiftingStatAudit
                .AsNoTracking()
                .Where(x => x.UserId == user.Id)
                .ProjectTo<LiftFeedDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(x => x.DateChanged)
                .Take(5)
                .ToListAsync(cancellationToken: cancellationToken);

            return liftFeed;
        }
    }
}
