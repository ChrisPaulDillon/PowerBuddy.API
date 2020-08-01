using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.Persistence;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateProgramService : ITemplateProgramService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateProgramService(PowerLiftingContext context, IMapper mapper)
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

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            return templateProgram;
        }

        public async Task<string> GetTemplateProgramNameById(int templateProgramId)
        {
            var template = await _context.Set<TemplateProgram>().Where(x => x.TemplateProgramId == templateProgramId)
                .Select(x => x.Name)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(string.IsNullOrEmpty(template)) throw new TemplateProgramNotFoundException();

            return template;
        }

        public async Task<TemplateProgramDTO> CreateTemplateProgram(TemplateProgramDTO templateProgramDTO)
        {
            var isTaken = await _context.Set<TemplateProgram>().AsNoTracking().AnyAsync(x => x.Name == templateProgramDTO.Name);
            if (isTaken) throw new TemplateProgramNameAlreadyExistsException();

            var template = _mapper.Map<TemplateProgram>(templateProgramDTO);
            _context.Add(template);

            await _context.SaveChangesAsync();
            return templateProgramDTO;
        }
    }
}