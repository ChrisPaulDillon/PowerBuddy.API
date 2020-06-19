using System;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Services
{
    public interface IProgramLogRepSchemeService
    {
        /// <summary>
        /// Create a new program log rep scheme, assuming the user has done
        /// an additional set etc
        /// </summary>
        Task<ProgramLogRepScheme> CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Marks a program log rep scheme as complete or non complete
        /// </summary>
        Task<bool> MarkProgramLogRepSchemeComplete(int programLogRepSchemeId, bool isCompleted);

        /// <summary>
        /// Allows a user to update weight lifted, comment etc on a given program rep
        /// </summary>
        Task<bool> UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Deletes a program log rep scheme, assuming the user did not finish a prescribed set?
        /// </summary>
        Task<bool> DeleteProgramLogRepScheme(int programLogRepSchemeId);
    }
}
