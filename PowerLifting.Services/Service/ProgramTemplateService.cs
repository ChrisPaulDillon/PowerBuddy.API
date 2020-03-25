using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Entities.Model.Programs;
using System.Collections.Generic;
using AutoMapper;
using PowerLifting.Entities.DTOs.Programs;

namespace Powerlifting.Services.Service
{
    public class ProgramTemplateService : ServiceBase<ProgramTemplate>, IProgramTemplateService
    {
        private IMapper _mapper;

        public ProgramTemplateService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramTemplateDTO>> GetAllProgramTemplates()
        {
            var programTemplates = await PowerliftingContext.Set<ProgramTemplate>().Include(x => x.ProgramExercises).ThenInclude(s => s.IndividualSets).ToListAsync();
            var programTemplateDTO = _mapper.Map<IEnumerable<ProgramTemplateDTO>>(programTemplates);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateById(int programId)
        {
            var programTemplate = await PowerliftingContext.Set<ProgramTemplate>().Where(x => x.ProgramTypeId == programId).FirstOrDefaultAsync();
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTypeByName(string programName)
        {
            var programTemplate = await PowerliftingContext.Set<ProgramTemplate>().Where(x => x.Name == programName).FirstOrDefaultAsync();
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType)
        {
            throw new System.NotImplementedException();
        }


    }
}
