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
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Notifications.Command.Account;

namespace PowerLifting.MediatR.Notifications.CommandHandler.Account
{
    public class MarkNotificationReadCommandHandler : IRequestHandler<MarkNotificationReadCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public MarkNotificationReadCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        {
            var notificationInteraction = await _context.Set<NotificationInteraction>()
                .Where(x => x.NotificationInteractionId == request.NotificationInteractionId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (notificationInteraction == null) throw new NotificationInteractionNotFoundException();

            var notificationEntity = _mapper.Map<NotificationInteraction>(notificationInteraction);
            _context.NotificationInteraction.Update(notificationEntity);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}