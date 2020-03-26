﻿using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Powerlifting.Services.ProgramTemplates.DTO;
using PowerLifting.Services.ProgramTemplates;

namespace Powerlifting.Services.ProgramTemplates
{
    public class ProgramTemplateService : IProgramTemplateService
    {
        private IMapper _mapper;
        private IProgramTemplateRepository _repo;

        public ProgramTemplateService(IProgramTemplateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramTemplateDTO>> GetAllProgramTemplates()
        {
            var programTemplates = await _repo.GetAllProgramTemplates();
            var programTemplateDTO = _mapper.Map<IEnumerable<ProgramTemplateDTO>>(programTemplates);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateById(int programTemplateId)
        {
            var programTemplate = await _repo.GetProgramTemplateById(programTemplateId);
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateByName(string programName)
        {
            var programTemplate = await _repo.GetProgramTemplateByName(programName);
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType)
        {
            throw new System.NotImplementedException();
        }
    }
}
