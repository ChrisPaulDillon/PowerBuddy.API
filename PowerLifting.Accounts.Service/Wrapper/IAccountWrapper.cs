using PowerLifting.Accounts.Repository;

namespace PowerLifting.Accounts.Service.Wrapper
{
    public interface IAccountWrapper
    {
        IUserRepository User { get; }
        IUserSettingRepository UserSetting { get; }
    }
}
