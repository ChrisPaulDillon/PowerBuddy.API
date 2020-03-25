using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs.Programs;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;

namespace Powerlifting.Contracts.Contracts
{
    public interface IProgramTemplateService : IServiceBase<ProgramTemplate>
    {
        Task<IEnumerable<ProgramTemplateDTO>> GetAllIncludeProgramExercises();
        Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType);
        Task<ProgramTemplateDTO> GetProgramTypeByName(string programType);
    }
}
