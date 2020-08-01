using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogRepSchemeService
    {
        Task<bool> CreateProgramLogExerciseCollection(IEnumerable<ProgramLogRepSchemeDTO> repSchemeCollection);

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
