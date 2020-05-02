using AutoMapper;

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
    }
}
