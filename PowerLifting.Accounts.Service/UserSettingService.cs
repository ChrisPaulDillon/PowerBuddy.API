using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Service;
using PowerLifting.Service.UserSettings.DTO;

namespace PowerLifting.Service.UserSettings
{
    public class UserSettingService : IUserSettingService
    {
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;

        public UserSettingService(IAccountWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserSettingDTO>> GetUserSettingsByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
