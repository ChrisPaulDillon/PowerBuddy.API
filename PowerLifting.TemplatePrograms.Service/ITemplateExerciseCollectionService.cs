using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.LiftingStats;

namespace PowerLifting.TemplatePrograms.Service
{
    public interface ITemplateExerciseCollectionService
    {
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId);

        Task<IEnumerable<LiftingStat>> DoesUserHaveExerciseCollection1RMSet(int templateProgramId, string userId);
    }
}