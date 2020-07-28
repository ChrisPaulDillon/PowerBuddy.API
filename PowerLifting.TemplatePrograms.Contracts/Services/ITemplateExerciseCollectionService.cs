using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerLifting.TemplatePrograms.Contracts.Services
{
    public interface ITemplateExerciseCollectionService
    {
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId);
    }
}