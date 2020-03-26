using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramTemplates.DTO;
using Powerlifting.Services.ServiceWrappers;

namespace Powerlifting.Services.ProgramTemplates
{
    public interface IProgramTemplateService : IServiceBase<ProgramTemplate>
    {
        Task<IEnumerable<ProgramTemplateDTO>> GetAllProgramTemplates();
        Task<ProgramTemplateDTO> GetProgramTemplateById(int programTemplateId);
        Task<ProgramTemplateDTO> GetProgramTypeByName(string programType);
        Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType);
    }
}
