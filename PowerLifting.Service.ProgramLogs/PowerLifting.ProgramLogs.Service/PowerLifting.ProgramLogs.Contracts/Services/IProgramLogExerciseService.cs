using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Services
{
    public interface IProgramLogExerciseService
    {
        /// <summary>
        /// Gets all exercises for a given program log day
        /// </summary>
        /// <param name="programLogDayId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId);

        /// <summary>
        /// Gets a specific ProgramLogExercise By Ids
        /// </summary>
        Task<ProgramLogExerciseDTO> GetProgramLogExerciseById(int programLogExerciseId);

        /// <summary>
        /// Creates a new program exercise for a specific log
        /// </summary>
        Task<ProgramLogExercise> CreateProgramLogExercise(string userId, CProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Marks a program log exercise completed
        /// </summary>
        Task<bool> MarkProgramLogExerciseComplete(int programLogExerciseId, bool isCompleted);

        /// <summary>
        /// Updates a given program log exercise, this could be the number of sets,
        /// a new comment etc
        /// </summary>
        Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Deletes a given program log exercise
        /// </summary>
        Task<bool> DeleteProgramLogExercise(int programLogExerciseId);

        /// <summary>
        /// Checks for an existing audit,
        /// creates a new one or updates the existing
        /// </summary>
        Task<int> CreateProgramLogExerciseAudit(string userId, int exerciseId);

        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId);
    }
}
