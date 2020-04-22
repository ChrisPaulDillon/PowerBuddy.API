using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.Contracts
{
    public interface ITemplateExerciseCollectionRepository : IRepositoryBase<TemplateExerciseCollection>
    {
        /// <summary>
        /// Used to retrieve all exerciseIds associated with a given template
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<int>> GetTemplateExerciseCollectionByTemplateId(int templateId);
    }
}
