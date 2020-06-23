using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.TemplatePrograms.Contracts.Repositories;
using AutoMapper;
using PowerLifting.Service.TemplatePrograms.DTO;
using AutoMapper.QueryableExtensions;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateProgramRepository : ITemplateProgramRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public TemplateProgramRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms()
        {
            return await _context.Set<TemplateProgram>().AsNoTracking()
                                                        .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                                                        .ToListAsync();
        }

        public async Task<TemplateProgramDTO> GetTemplateProgramById(int templateProgramId)
        {
            var templateProgram = await _context.Set<TemplateProgram>().AsNoTracking()
                                                             .Where(x => x.TemplateProgramId == templateProgramId)
                                                             .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                                                             .FirstOrDefaultAsync();

            if (templateProgram != null && templateProgram.TemplateWeeks != null)
            {
                templateProgram.TemplateWeeks = templateProgram.TemplateWeeks.OrderBy(x => x.WeekNo);
                return templateProgram;
            }
            return null;
        }

        public async Task<bool> DoesNameExist(string programTemplate)
        {
            return await _context.Set<TemplateProgram>().AsNoTracking().AnyAsync(x => x.Name == programTemplate);
        }

        public async Task<TemplateProgram> CreateTemplateProgram(TemplateProgramDTO templateProgramDTO)
        {
            var template = _mapper.Map<TemplateProgram>(templateProgramDTO);
            _context.Add(template);

            await _context.SaveChangesAsync();
            return template;
        }
    }
}
