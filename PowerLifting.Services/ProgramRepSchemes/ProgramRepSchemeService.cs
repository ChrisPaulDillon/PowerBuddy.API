using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Powerlifting.Services.ProgramTemplates.DTO;
using PowerLifting.Repositorys.RepositoryWrappers;
using Powerlifting.Services.ProgramTemplates.Model;

namespace Powerlifting.Services.ProgramTemplates
{
    public class ProgramRepSchemeService : IProgramRepSchemeService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ProgramRepSchemeService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
