using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.TemplatePrograms.Contracts.Repositories
{
    public interface ITemplateProgramRepository
    {
        /// <summary>
        /// Gets a top level view of all the template programs such as program name, difficulty etc.
        /// </summary>
        Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms();

        /// <summary>
        /// Gets a singular template program by id
        /// </summary>
        Task<TemplateProgramDTO> GetTemplateProgramById(int templateProgramId);

        /// <summary>
        /// Gets a singular template program name by id
        /// </summary>
        Task<string> GetTemplateProgramNameById(int templateProgramId);

        /// <summary>
        /// Used to determine if the name of the program already exists
        /// </summary>
        Task<bool> DoesNameExist(string programName);

        /// <summary>
        /// Creates a new template program
        /// </summary>
        Task<TemplateProgram> CreateTemplateProgram(TemplateProgramDTO templateProgram);
    }
}