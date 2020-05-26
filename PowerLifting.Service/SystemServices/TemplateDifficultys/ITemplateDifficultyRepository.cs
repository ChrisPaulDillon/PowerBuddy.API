using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;

namespace PowerLifting.Service.SystemServices.TemplateDifficultys
{
    public interface ITemplateDifficultyRepository : IRepositoryBase<TemplateDifficulty>
    {
        Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties();
    }
}
