using PowerLifting.Accounts.Contracts;

namespace PowerLifting.Accounts.Service
{
    public interface IAccountWrapper
    {
        IUserRepository User { get; }
        IUserSettingRepository UserSetting { get; }
    }
}
