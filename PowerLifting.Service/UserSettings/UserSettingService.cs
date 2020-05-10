using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.UserSettings.DTO;

namespace PowerLifting.Service.UserSettings
{
    public class UserSettingService : IUserSettingService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public UserSettingService(IRepositoryWrapper repo, IMapper mapper)
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
