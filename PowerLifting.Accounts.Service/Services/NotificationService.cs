using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Entity.Users.Model;

namespace PowerLifting.Accounts.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;

        public NotificationService(IAccountWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Notification> CreateNotification(NotificationDTO notificationDTO)
        {
            var notification = await _repo.Notification.CreateNotification(notificationDTO);
            var users = await _repo.User.GetAllUsers();

            var notificationInteractionList = users.ToList().Select(x => new NotificationInteraction()
            {
                NotificationId = notification.NotificationId,
                UserId = x.Id,
                HasRead = false
            });

            await _repo.Notification.CreateNotificationInteraction(notificationInteractionList);
            return notification;
        }

        public async Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId)
        {
            return await _repo.Notification.GetUserNotifications(userId);
        }

        public async Task<bool> MarkNotificationAsRead(int notificationInteractionId)
        {
            var notification = await _repo.Notification.GetNotificationInteractionById(notificationInteractionId);

            return await _repo.Notification.MarkNotificationAsRead(notification);
        }
    }
}
