using System;
using System.Collections.Generic;

namespace PowerLifting.TemplatePrograms.Contracts.Repositories
{
    public interface ITemplateExerciseCollectionRepository
    {
        /// <summary>
        /// Used to retrieve all exerciseIds associated with a given template
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateId(int templateId);
    }
}
