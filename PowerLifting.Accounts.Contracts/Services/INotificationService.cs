using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Entity.Users.Model;

namespace PowerLifting.Accounts.Contracts.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId);
        Task<bool> MarkNotificationAsRead(int notificationInteractionId);
    }
}
