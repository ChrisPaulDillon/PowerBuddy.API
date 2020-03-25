using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs.Programs;
using PowerLifting.Entities.Model.Programs;

namespace Powerlifting.Contracts.Contracts
{
    public interface IProgramTemplateService : IServiceBase<ProgramTemplate>
    {
        Task<IEnumerable<ProgramTemplateDTO>> GetAllProgramTemplates();
        Task<ProgramTemplateDTO> GetProgramTemplateById(int programTemplateId);
        Task<ProgramTemplateDTO> GetProgramTypeByName(string programType);
        Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType);
    }
}
