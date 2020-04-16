using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms;
using Powerlifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Repositories
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
                                                                   .ThenInclude(x => x.TemplateRepSchemes)
                                                                   .ToListAsync();
        }

        public async Task<TemplateProgram> GetTemplateProgramById(int programTemplateId)
        {
            return await PowerliftingContext.Set<TemplateProgram>().Include(x => x.TemplateWeeks)
                                                                   .ThenInclude(x => x.TemplateDays)
                                                                   .ThenInclude(x => x.TemplateExercises)
                                                                   .ThenInclude(x => x.TemplateRepSchemes)
                                                                   .FirstOrDefaultAsync();
        }

        public async Task<TemplateProgram> GetTemplateProgramByName(string programTemplate)
        {
            return await PowerliftingContext.Set<TemplateProgram>().Where(x => x.Name == programTemplate).FirstOrDefaultAsync();
        }

        public Task<TemplateProgram> CreateTemplateProgram(TemplateProgram programType)
        {
            throw new System.NotImplementedException();
        }

      
    }
}
