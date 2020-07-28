using System.Collections.Generic;

namespace PowerLifting.TemplatePrograms.Service
{
    public interface ITemplateExerciseCollectionService
    {
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId);
    }
}