using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogRepSchemeRepository : IRepositoryBase<ProgramLogRepScheme>
    {
        /// <summary>
        /// Gets a specific program log rep scheme
        /// </summary>
        Task<ProgramLogRepScheme> GetProgramLogRepSchemeById(int programLogRepSchemeId);

        /// <summary>
        /// Allows the user to add another set / rep onto a given exercise
        /// </summary>
        Task CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

        /// <summary>
        /// Updates a given program log rep scheme, this could be weight lifted, comments,
        /// rep range etc
        /// </summary>
        Task<bool> UpdateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

        /// <summary>
        /// Deletes a given program log rep scheme, maybe the user did not finish the set
        /// </summary>
        Task<bool> DeleteProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

        Task<bool> DoesRepSchemeExist(int programLogRepSchemeId);
    }
}