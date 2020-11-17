using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Notifications.Commands.Admin
{
    public class CreateNotificationCommand : IRequest<NotificationDTO>
    {
        public NotificationDTO NotificationDTO { get; }
        public string UserId { get; }
        public CreateNotificationCommand(NotificationDTO notificationDTO, string userId)
        {
            NotificationDTO = notificationDTO;
            UserId = userId;
        }
    }
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, NotificationDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateNotificationCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationDTO> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification()
            {
                NotificationText = request.NotificationDTO.NotificationText
            };
            _context.Notification.Add(notification);

            var users = await _context.User.Select(x => x.Id).ToListAsync(cancellationToken: cancellationToken);

            var notificationInteractionList = users.ToList().Select(x => new NotificationInteraction()
            {
                NotificationId = notification.NotificationId,
                UserId = x,
                HasRead = false
            });

            notificationInteractionList.ToList().ForEach(x => _context.NotificationInteraction.Add(x));
            await _context.SaveChangesAsync(cancellationToken);
            return request.NotificationDTO;
        }
    }
}