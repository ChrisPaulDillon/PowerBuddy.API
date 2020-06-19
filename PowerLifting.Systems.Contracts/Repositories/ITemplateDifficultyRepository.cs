using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.TemplateDifficultys.DTO;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface ITemplateDifficultyRepository
    {
        Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties();
    }
}
