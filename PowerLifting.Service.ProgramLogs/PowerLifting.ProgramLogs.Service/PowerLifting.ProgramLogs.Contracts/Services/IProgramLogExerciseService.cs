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
        /// Creates a new program exercise for a specific log
        /// </summary>
        /// <param name="programLogExercise"></param>
        /// <returns></returns>
        Task CreateProgramLogExercise(string userId, ProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Updates a given program log exercise, this could be the number of sets,
        /// a new comment etc
        /// </summary>
        /// <param name="programLogExercise"></param>
        /// <returns></returns>
        Task UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Deletes a given program log exercise
        /// </summary>
        /// <param name="programLogExerciseId"></param>
        /// <returns></returns>
        Task DeleteProgramLogExercise(int programLogExerciseId);

        /// <summary>
        /// Checks for an existing audit,
        /// creates a new one or updates the existing
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="exerciseId"></param>
        /// <returns></returns>
        Task CreateProgramLogExerciseAudit(string userId, int exerciseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId);
    }
}
