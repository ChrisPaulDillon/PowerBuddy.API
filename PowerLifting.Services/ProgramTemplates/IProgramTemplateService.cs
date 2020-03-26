﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramTemplates.DTO;

namespace Powerlifting.Services.ProgramTemplates
{
    public interface IProgramTemplateService
    {
        Task<IEnumerable<ProgramTemplateDTO>> GetAllProgramTemplates();
        Task<ProgramTemplateDTO> GetProgramTemplateById(int programTemplateId);
        Task<ProgramTemplateDTO> GetProgramTemplateByName(string programType);
        Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType);
    }
}
