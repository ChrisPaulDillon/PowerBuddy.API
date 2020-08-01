using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogExerciseService
    {
        /// <summary>
        /// Gets all exercises for a given program log day
        /// </summary>
        Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId, string userId);

        /// <summary>
        /// Gets a specific ProgramLogExercise By Ids
        /// </summary>
        Task<ProgramLogExercise> GetProgramLogExerciseById(int programLogExerciseId);

        /// <summary>
        /// Creates a new program exercise for a specific log
        /// </summary>
        Task<ProgramLogExerciseDTO> CreateProgramLogExercise(CProgramLogExerciseDTO programLogExercise, string userId);

        /// <summary>
        /// Marks a program log exercise completed
        /// </summary>
        Task<bool> MarkProgramLogExerciseComplete(int programLogExerciseId, bool isCompleted);

        /// <summary>
        /// Updates a given program log exercise, this could be the number of sets,
        /// a new comment etc
        /// </summary>
        Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExercise, string userId);

        /// <summary>
        /// Deletes a given program log exercise
        /// </summary>
        Task<bool> DeleteProgramLogExercise(int programLogExerciseId, string userId);

        /// <summary>
        /// Checks for an existing audit,
        /// creates a new one or updates the existing
        /// </summary>
        Task<int> CreateProgramLogExerciseAudit(string userId, int exerciseId);

        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId);
    }
}
