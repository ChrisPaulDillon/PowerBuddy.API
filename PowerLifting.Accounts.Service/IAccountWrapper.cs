using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Contracts.Repositories;

namespace PowerLifting.Accounts.Service
{
    public interface IAccountWrapper
    {
        IUserRepository User { get; }
        IUserSettingRepository UserSetting { get; }
    }
}
