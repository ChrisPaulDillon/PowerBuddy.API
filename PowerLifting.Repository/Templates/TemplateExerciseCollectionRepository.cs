using System.Collections.Generic;
using System.Linq;
using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateExerciseCollectionRepository : RepositoryBase<TemplateExerciseCollection>,
                                                        ITemplateExerciseCollectionRepository
    {
        public TemplateExerciseCollectionRepository(PowerliftingContext context) : base(context)
        {
        }

        public IEnumerable<int> GetTemplateExerciseCollectionByTemplateId(int templateId)
        {
            return PowerliftingContext.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == templateId)
                                                                              .Select(x => x.ExerciseId)
                                                                              .ToList();
            
        }
    }
}
