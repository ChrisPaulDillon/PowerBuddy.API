using AutoMapper;
using PowerLifting.Repositorys.RepositoryWrappers;
using Powerlifting.Services.TemplatePrograms;

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
