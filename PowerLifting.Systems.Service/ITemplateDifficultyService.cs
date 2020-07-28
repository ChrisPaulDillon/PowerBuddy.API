using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Systems.Service
{
    public interface ITemplateDifficultyService 
    {
        Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties();
    }
}
