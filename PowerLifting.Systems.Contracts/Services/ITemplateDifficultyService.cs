using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.TemplateDifficultys.DTO;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface ITemplateDifficultyService 
    {
        Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties();
    }
}
