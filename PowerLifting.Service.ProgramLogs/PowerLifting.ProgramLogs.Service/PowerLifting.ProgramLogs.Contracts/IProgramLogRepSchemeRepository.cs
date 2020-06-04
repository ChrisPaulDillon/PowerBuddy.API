using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts
{
    public interface IProgramLogRepSchemeRepository : IRepositoryBase<ProgramLogRepScheme>
    {
        /// <summary>
        /// Gets a specific program log rep scheme
        /// </summary>
        /// <param name="programLogRepSchemeId"></param>
        /// <returns></returns>
        Task<ProgramLogRepScheme> GetProgramLogRepScheme(int programLogRepSchemeId);

        /// <summary>
        /// Allows the user to add another set / rep onto a given exercise
        /// </summary>
        /// <param name="programLogRepScheme"></param>
        /// <returns></returns>
        void CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

        /// <summary>
        /// Updates a given program log rep scheme, this could be weight lifted, comments,
        /// rep range etc
        /// </summary>
        /// <param name="programLogRepScheme"></param>
        void UpdateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

        /// <summary>
        /// Deletes a given program log rep scheme, maybe the user did not finish the set
        /// </summary>
        /// <param name="programLogRepScheme"></param>
        void DeleteProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

    }
}