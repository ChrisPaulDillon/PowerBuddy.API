using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId);
        Task<bool> MarkNotificationAsRead(int notificationInteractionId);
        Task<Notification> CreateNotification(NotificationDTO notificationDTO);
    }
}
