using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Persistence;
using AutoMapper;

namespace PowerLifting.Accounts.Repository
{
    public class UserSettingRepository : IUserSettingRepository
    {
        public UserSettingRepository(PowerliftingContext context, IMapper mapper)
        {

        }
    }
}
