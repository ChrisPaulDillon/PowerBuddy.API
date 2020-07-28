using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Systems.Repository
{
    public interface ITemplateDifficultyRepository
    {
        Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties();
    }
}
