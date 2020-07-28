using AutoMapper;
using PowerLifting.Accounts.Repository;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service.Wrapper
{
    public class AccountWrapper : IAccountWrapper
    {
        private IUserRepository _userRepo;
        private IUserSettingRepository _userSettingRepo;
        private INotificationRepository _notificationRepo;
        private IFriendsListRepository _friendsListRepo;

        private readonly IMapper _mapper;

        private readonly PowerLiftingContext _context;

        public AccountWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
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

        public IFriendsListRepository FriendsList
        {
            get
            {
                if (_friendsListRepo == null)
                {
                    _friendsListRepo = new FriendsListRepository(_context, _mapper);
                }

                return _friendsListRepo;
            }
        }
    }
}
