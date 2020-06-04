using PowerLifting.Accounts.Contracts;
using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Accounts.Repository
{
    public class UserSettingRepository : RepositoryBase<UserSetting>, IUserSettingRepository
    {
        public UserSettingRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
