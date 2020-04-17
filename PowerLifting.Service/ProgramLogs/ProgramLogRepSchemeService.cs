using AutoMapper;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.ProgramLogs
{
    public class ProgramLogRepSchemeService : IProgramLogRepSchemeService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ProgramLogRepSchemeService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}