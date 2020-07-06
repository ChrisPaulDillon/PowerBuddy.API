using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Entity.Users.Model;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public NotificationRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId)
        {
            return await _context.Set<NotificationInteraction>()
                .Where(x => x.UserId == userId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<NotificationInteractionDTO> GetNotificationInteractionById(int notificationInteractionId)
        {
            return await _context.Set<NotificationInteraction>()
                .Where(x => x.NotificationInteractionId == notificationInteractionId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> MarkNotificationAsRead(NotificationInteractionDTO notificationInteraction)
        {
            var notificationEntity = _mapper.Map<NotificationInteraction>(notificationInteraction);
            _context.Update(notificationEntity);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
