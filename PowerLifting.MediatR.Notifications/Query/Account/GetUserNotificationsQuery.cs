using System.Collections.Generic;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Notifications.Query.Account
{
    public class GetUserNotificationsQuery : IRequest<IEnumerable<NotificationInteractionDTO>>
    {
        public string UserId { get; }
        public GetUserNotificationsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
