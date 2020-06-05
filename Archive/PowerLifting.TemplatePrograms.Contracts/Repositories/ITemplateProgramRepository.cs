using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.TemplatePrograms.Contracts.Repositories
{
    public interface ITemplateProgramRepository : IRepositoryBase<TemplateProgram>
    {
        /// <summary>
        /// Gets a top level view of all the template programs such as program name, difficulty etc.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TemplateProgram>> GetAllTemplatePrograms();

        /// <summary>
        /// Gets a singular template program by id
        /// </summary>
        /// <param name="templateProgramId"></param>
        /// <returns></returns>
        TemplateProgram GetTemplateProgramById(int templateProgramId);

        /// <summary>
        /// Used to determine if the name of the program already exists
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        Task<bool> GetTemplateProgramByName(string programName);

        /// <summary>
        /// Creates a new template program
        /// </summary>
        /// <param name="templateProgram"></param>
        void CreateTemplateProgram(TemplateProgram templateProgram);
    }
}