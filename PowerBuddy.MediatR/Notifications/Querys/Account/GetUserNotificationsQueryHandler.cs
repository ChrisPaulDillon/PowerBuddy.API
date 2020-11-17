using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Notifications.Querys.Account
{
    public class GetUserNotificationsQuery : IRequest<IEnumerable<NotificationInteractionDTO>>
    {
        public string UserId { get; }
        public GetUserNotificationsQuery(string userId)
        {
            UserId = userId;
        }
    }
    public class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, IEnumerable<NotificationInteractionDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetUserNotificationsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationInteractionDTO>> Handle(GetUserNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<NotificationInteraction>()
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}