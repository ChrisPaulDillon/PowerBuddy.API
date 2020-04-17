using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;

namespace PowerLifting.Service.TemplatePrograms
{
    public class TemplateRepSchemeService : ITemplateRepSchemeService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public TemplateRepSchemeService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}