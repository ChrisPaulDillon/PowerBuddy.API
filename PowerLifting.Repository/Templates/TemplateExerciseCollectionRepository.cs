using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Contracts;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateExerciseCollectionRepository : RepositoryBase<TemplateExerciseCollection>,
                                                        ITemplateExerciseCollectionRepository
    {
        public TemplateExerciseCollectionRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TemplateExerciseCollection>> GetTemplateExerciseCollectionByTemplateId(int templateId)
        {
            return await PowerliftingContext.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == templateId)
                                                                              .ToListAsync();
            
        }
    }
}
