﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
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

        public async Task<Notification> CreateNotification(NotificationDTO notificationDTO)
        {
            var notification = new Notification()
            {
                NotificationText = notificationDTO.NotificationText
            };
            _context.Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task CreateNotificationInteraction(IEnumerable<NotificationInteraction> notificationInteractions)
        {
            notificationInteractions.ToList().ForEach(x => _context.Add(x));
            await _context.SaveChangesAsync();
        }
    }
}
