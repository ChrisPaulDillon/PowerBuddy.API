using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.TemplatePrograms.Repository.Contracts
{
    public interface ITemplateDifficultyRepository
    {
        Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties();
    }
}
