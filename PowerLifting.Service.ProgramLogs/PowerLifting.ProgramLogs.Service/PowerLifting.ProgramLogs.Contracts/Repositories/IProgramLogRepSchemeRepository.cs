using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogRepSchemeRepository
    {
        /// <summary>
        /// Gets a specific program log rep scheme
        /// </summary>
        Task<ProgramLogRepScheme> GetProgramLogRepSchemeById(int programLogRepSchemeId);

        /// <summary>
        /// Allows the user to add another set / rep onto a given exercise
        /// </summary>
        Task<ProgramLogRepScheme> CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepScheme);

        /// <summary>
        /// Updates a given program log rep scheme, this could be weight lifted, comments,
        /// rep range etc
        /// </summary>
        Task<bool> UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepScheme);

        /// <summary>
        /// Updates a given program log rep scheme, this could be weight lifted, comments,
        /// rep range etc
        /// </summary>
        Task<bool> MarkProgramLogRepSchemeComplete(ProgramLogRepScheme programLogRepScheme);

        /// <summary>
        /// Deletes a given program log rep scheme, maybe the user did not finish the set
        /// </summary>
        Task<bool> DeleteProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepScheme);

        Task<bool> DoesRepSchemeExist(int programLogRepSchemeId);
    }
}