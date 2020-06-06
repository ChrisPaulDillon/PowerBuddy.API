using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.TemplatePrograms.Contracts.Repositories;
using AutoMapper;
using PowerLifting.Service.TemplatePrograms.DTO;
using AutoMapper.QueryableExtensions;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateProgramRepository : RepositoryBase<TemplateProgram>, ITemplateProgramRepository
    {
        private readonly IMapper _mapper;

        public TemplateProgramRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms()
        {
            return await PowerliftingContext.Set<TemplateProgram>().AsNoTracking()
                                                                   .Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.Exercise)
                                                                   .Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.TemplateRepSchemes)
                                                                   .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                                                                   .ToListAsync();
        }

        public TemplateProgramDTO GetTemplateProgramById(int templateProgramId)
        {
            return PowerliftingContext.Set<TemplateProgram>().AsNoTracking()
                                                             .Where(x => x.TemplateProgramId == templateProgramId)
                                                             .Include(x => x.TemplateWeeks)
                                                             .ThenInclude(x => x.TemplateDays)
                                                             .ThenInclude(x => x.TemplateExercises)
                                                             .ThenInclude(x => x.Exercise)
                                                             .Include(x => x.TemplateWeeks)
                                                             .ThenInclude(x => x.TemplateDays)
                                                             .ThenInclude(x => x.TemplateExercises)
                                                             .ThenInclude(x => x.TemplateRepSchemes)
                                                             .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                                                             .FirstOrDefault();
        }

        public async Task<bool> DoesNameExist(string programTemplate)
        {
            return await PowerliftingContext.Set<TemplateProgram>().AsNoTracking().AnyAsync(x => x.Name == programTemplate);
        }

        public void CreateTemplateProgram(TemplateProgram templateProgram)
        {
            Create(templateProgram);
        }
    }
}
