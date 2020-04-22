using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.Contracts
{
    public interface ITemplateExerciseCollectionRepository : IRepositoryBase<TemplateExerciseCollection>
    {
        /// <summary>
        /// Used to retrieve all exercises associated with a given template
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        Task<IEnumerable<TemplateExerciseCollection>> GetTemplateExerciseCollectionByTemplateId(int templateId);
    }
}
