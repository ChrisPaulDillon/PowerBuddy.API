using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.Accounts.Service;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Service
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

        public async Task<UserSettingDTO> GetUserSettingsByUserId(string userId)
        {
            return await _repo.UserSetting.GetUserSettingsById(userId);
        }
    }
}
