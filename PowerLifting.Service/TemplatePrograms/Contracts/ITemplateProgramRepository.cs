using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.Contracts.Repositories
{
    public interface ITemplateProgramRepository : IRepositoryBase<TemplateProgram>
    {
        /// <summary>
        /// Gets a top level view of all the template programs such as program name, difficulty etc.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TemplateProgram>> GetAllTemplatePrograms();

        Task<TemplateProgram> GetTemplateProgramById(int templateProgramId);

        /// <summary>
        /// Used to determine if the name of the program already exists
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        Task<bool> GetTemplateProgramByName(string programName);
        void CreateTemplateProgram(TemplateProgram templateProgram);
    }
}