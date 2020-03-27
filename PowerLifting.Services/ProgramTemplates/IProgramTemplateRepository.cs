using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramTemplates.Model;

namespace PowerLifting.Services.ProgramTemplates
{
    public interface IProgramTemplateRepository : IRepositoryBase<ProgramTemplate>
    {
        Task<IEnumerable<ProgramTemplate>> GetAllProgramTemplates();
        Task<ProgramTemplate> GetProgramTemplateById(int programTemplateId);
        Task<ProgramTemplate> GetProgramTemplateByName(string programType);
        Task<ProgramTemplate> CreateProgramTemplate(ProgramTemplate programType);
    }
}
