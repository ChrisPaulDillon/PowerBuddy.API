using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.TemplatePrograms.DTO;

namespace Powerlifting.Services.TemplatePrograms
{
    public interface ITemplateProgramService
    {
        Task<IEnumerable<TopLevelTemplateProgramDTO>> GetAllTemplatePrograms();
        Task<TemplateProgramDTO> GetTemplateProgramById(int programTemplateId);
        Task<TemplateProgramDTO> GetTemplateProgramByIdIncludeLiftingStats(int userId, int programTemplateId);
        Task<TemplateProgramDTO> GetTemplateProgramByName(string programType);
        Task<TemplateProgramDTO> CreateTemplateProgram(TemplateProgramDTO programType);
    }
}
