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

        private readonly PowerliftingContext _context;

        public AccountWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_context);
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
                    _userSettingRepo = new UserSettingRepository(_context);
                }

                return _userSettingRepo;
            }
        }
    }
}
