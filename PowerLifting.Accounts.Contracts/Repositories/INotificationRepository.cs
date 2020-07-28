using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Accounts.Contracts.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId);
        Task<NotificationInteractionDTO> GetNotificationInteractionById(int notificationInteractionId);
        Task<bool> MarkNotificationAsRead(NotificationInteractionDTO notificationInteraction);
        Task<Notification> CreateNotification(NotificationDTO notificationDTO);
        Task CreateNotificationInteraction(IEnumerable<NotificationInteraction> notificationInteractions);
    }
}
