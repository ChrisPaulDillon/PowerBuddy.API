using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.TemplateDifficultys.DTO;

namespace PowerLifting.Service.SystemServices.TemplateDifficultys
{
    public interface ITemplateDifficultyService 
    {
        Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties();
    }
}
