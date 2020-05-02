using PowerLifting.Persistence;
using Powerlifting.Repository;
using PowerLifting.Service.UserSettings;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Repository.UserSettings
{
    public class UserSettingRepository : RepositoryBase<UserSetting>, IUserSettingRepository
    {
        public UserSettingRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
