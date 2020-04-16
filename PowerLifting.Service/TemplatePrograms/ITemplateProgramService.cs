using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.TemplatePrograms.DTO;

namespace Powerlifting.Services.TemplatePrograms
{
    public interface ITemplateProgramService
    {
        /// <summary>
        /// Gets a top level view of all program templates such as program title, difficulty, number of weeks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms();

        /// <summary>
        /// Gets the template program by Id
        /// </summary>
        /// <param name="programTemplateId"></param>
        /// <returns></returns>
        Task<TemplateProgramDTO> GetTemplateProgramById(int programTemplateId);

        /// <summary>
        /// Creates a program template based upon the user viewing the programs lifting stats
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="programTemplateId"></param>
        /// <returns></returns>
        Task<TemplateProgramDTO> GenerateProgramTemplateForIndividual(string userId, int programTemplateId);

        Task<TemplateProgramDTO> GetTemplateProgramByName(string programType);
        Task<TemplateProgramDTO> CreateTemplateProgram(TemplateProgramDTO programType);
    }
}
