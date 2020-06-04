using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Service.SystemServices.TemplateDifficultys.Model;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface ITemplateDifficultyRepository : IRepositoryBase<TemplateDifficulty>
    {
        Task<IEnumerable<TemplateDifficulty>> GetAllTemplateDifficulties();
    }
}
