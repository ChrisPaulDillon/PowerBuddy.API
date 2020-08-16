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
using PowerLifting.Data.Entities.Account;
using PowerLifting.MediatR.Notifications.Command.Account;
using PowerLifting.MediatR.Notifications.Command.Admin;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.Notifications.CommandHandler.Account
{
    public class GetUserNotificationsCommandHandler : IRequestHandler<GetUserNotificationsCommand, IEnumerable<NotificationInteractionDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetUserNotificationsCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationInteractionDTO>> Handle(GetUserNotificationsCommand request, CancellationToken cancellationToken)
        {
            return await _context.Set<NotificationInteraction>()
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}