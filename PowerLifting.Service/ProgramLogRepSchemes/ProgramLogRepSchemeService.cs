using System;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Services.ProgramLogRepSchemes;

namespace PowerLifting.Services.ProgramLogRepSchemess
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
