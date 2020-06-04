using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Contracts.Contracts
{
    public interface ITemplateExerciseCollectionRepository : IRepositoryBase<TemplateExerciseCollection>
    {
        /// <summary>
        /// Used to retrieve all exerciseIds associated with a given template
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetTemplateExerciseCollectionByTemplateId(int templateId);
    }
}
