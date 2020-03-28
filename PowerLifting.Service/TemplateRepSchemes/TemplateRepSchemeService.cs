using AutoMapper;
using PowerLifting.Service.ServiceWrappers;

namespace Powerlifting.Services.TemplateRepSchemes
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
