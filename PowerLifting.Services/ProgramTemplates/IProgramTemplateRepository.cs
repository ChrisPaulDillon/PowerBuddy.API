using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramTemplates;
using Powerlifting.Services.ProgramTemplates.DTO;

namespace PowerLifting.Services.ProgramTemplates
{
    public interface IProgramTemplateRepository
    {
        Task<IEnumerable<ProgramTemplate>> GetAllProgramTemplates();
        Task<ProgramTemplate> GetProgramTemplateById(int programTemplateId);
        Task<ProgramTemplate> GetProgramTemplateByName(string programType);
        Task<ProgramTemplate> CreateProgramTemplate(ProgramTemplate programType);
    }
}
