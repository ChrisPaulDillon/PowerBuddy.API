using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.TemplatePrograms.Contracts.Services
{
    public interface ITemplateExerciseCollectionService
    {
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId);
    }
}