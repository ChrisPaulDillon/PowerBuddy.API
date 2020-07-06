using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Entity.Users.Model;

namespace PowerLifting.Accounts.Contracts.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId);
        Task<NotificationInteractionDTO> GetNotificationInteractionById(int notificationInteractionId);
        Task<bool> MarkNotificationAsRead(NotificationInteractionDTO notificationInteraction);
    }
}
