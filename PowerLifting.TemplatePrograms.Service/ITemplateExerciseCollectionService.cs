using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.TemplatePrograms.Service
{
    public interface ITemplateExerciseCollectionService
    {
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId);

        Task<IEnumerable<LiftingStat>> DoesUserHaveExerciseCollection1RMSet(int templateProgramId, string userId);
    }
}