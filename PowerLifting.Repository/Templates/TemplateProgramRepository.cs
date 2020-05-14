using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.TemplatePrograms.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Repository.Templates
{
    public class TemplateProgramRepository : RepositoryBase<TemplateProgram>, ITemplateProgramRepository
    {
        public TemplateProgramRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TemplateProgram>> GetAllTemplatePrograms()
        {
            return await PowerliftingContext.Set<TemplateProgram>().Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.Exercise)
                                                                   .Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.TemplateRepSchemes)
                                                                   .ToListAsync();
        }

        public TemplateProgram GetTemplateProgramById(int templateProgramId)
        {
            return PowerliftingContext.Set<TemplateProgram>().Where(x => x.TemplateProgramId == templateProgramId)
                                                                   .Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.Exercise)
                                                                   .Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.TemplateRepSchemes)
                                                                   .FirstOrDefault();
        }

        public async Task<bool> GetTemplateProgramByName(string programTemplate)
        {
            return await PowerliftingContext.Set<TemplateProgram>().AnyAsync(x => x.Name == programTemplate);
        }

        public void CreateTemplateProgram(TemplateProgram templateProgram)
        {
            Create(templateProgram);
        }
    }
}
