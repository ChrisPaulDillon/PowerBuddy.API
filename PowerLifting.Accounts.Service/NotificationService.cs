using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Accounts.Service.Wrapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service
{
    public class NotificationService : INotificationService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;

        public NotificationService(PowerLiftingContext context, IAccountWrapper repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Notification> CreateNotification(NotificationDTO notificationDTO)
        {
            var notification = new Notification()
            {
                NotificationText = notificationDTO.NotificationText
            };
            _context.Add(notification);

            var users = await _repo.User.GetAllUsers();

            var notificationInteractionList = users.ToList().Select(x => new NotificationInteraction()
            {
                NotificationId = notification.NotificationId,
                UserId = x.Id,
                HasRead = false
            });

            notificationInteractionList.ToList().ForEach(x => _context.Add(x));
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<NotificationInteractionDTO>> GetUserNotifications(string userId)
        {
            return await _context.Set<NotificationInteraction>()
                .Where(x => x.UserId == userId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> MarkNotificationAsRead(int notificationInteractionId)
        {
            var notificationInteraction =  await _context.Set<NotificationInteraction>()
                .Where(x => x.NotificationInteractionId == notificationInteractionId)
                .ProjectTo<NotificationInteractionDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (notificationInteraction == null) throw new NotificationInteractionNotFoundException();

            var notificationEntity = _mapper.Map<NotificationInteraction>(notificationInteraction);
            _context.Update(notificationEntity);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
