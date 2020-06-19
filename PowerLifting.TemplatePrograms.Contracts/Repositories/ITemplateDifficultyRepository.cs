using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;

namespace PowerLifting.TemplatePrograms.Contracts.Repositories
{
    public interface ITemplateDifficultyRepository
    {
        Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties();
    }
}
