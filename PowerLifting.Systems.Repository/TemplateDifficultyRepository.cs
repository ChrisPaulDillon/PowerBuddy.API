using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;
using PowerLifting.TemplatePrograms.Contracts;

namespace PowerLifting.Systems.Repository
{
    public class TemplateDifficultyRepository : RepositoryBase<TemplateDifficulty>, ITemplateDifficultyRepository
    {
        public TemplateDifficultyRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties()
        {
            return await PowerliftingContext.Set<TemplateDifficulty>().AsNoTracking().ToListAsync();
        }
    }
}
