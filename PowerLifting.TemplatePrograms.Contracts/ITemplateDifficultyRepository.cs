using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;

namespace PowerLifting.TemplatePrograms.Contracts
{
    public interface ITemplateDifficultyRepository : IRepositoryBase<TemplateDifficulty>
    {
        Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties();
    }
}
