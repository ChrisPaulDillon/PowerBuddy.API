using AutoMapper;
using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Accounts.Repository;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service
{
    public class AccountWrapper : IAccountWrapper
    {
        private IUserRepository _userRepo;
        private IUserSettingRepository _userSettingRepo;
        private INotificationRepository _notificationRepo;

        private readonly IMapper _mapper;

        private readonly PowerliftingContext _context;

        public AccountWrapper(PowerliftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_context, _mapper);
                }

                return _userRepo;
            }
        }

        public IUserSettingRepository UserSetting
        {
            get
            {
                if (_userSettingRepo == null)
                {
                    _userSettingRepo = new UserSettingRepository(_context, _mapper);
                }

                return _userSettingRepo;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_notificationRepo == null)
                {
                    _notificationRepo = new NotificationRepository(_context, _mapper);
                }

                return _notificationRepo;
            }
        }
    }
}
