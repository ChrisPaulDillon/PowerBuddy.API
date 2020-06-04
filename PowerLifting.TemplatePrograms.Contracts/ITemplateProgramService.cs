using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.TemplatePrograms.Contracts
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
        TemplateProgramDTO GetTemplateProgramById(int programTemplateId);

        /// <summary>
        /// Creates a program template based upon the user viewing the programs lifting stats
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="programTemplateId"></param>
        /// <returns></returns>
        TemplateProgramDTO GenerateProgramTemplateForIndividual(string userId, int programTemplateId, IEnumerable<LiftingStatDTO> liftingStats);

        /// <summary>
        /// Creates a new program template, possibly to be used by an admin or custom program creation
        /// </summary>
        /// <param name="programTemplateDTO"></param>
        /// <returns></returns>
        Task CreateTemplateProgram(TemplateProgramDTO programTemplateDTO);
    }
}