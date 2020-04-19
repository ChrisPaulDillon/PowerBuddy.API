using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.DTO;

namespace PowerLifting.Service.ProgramLogs.Contracts.Services
{
    public interface IProgramLogService
    {
        #region ProgramLog Services
        /// <summary>
        /// Gets all program log to show to the user what their workout will be
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId);

        /// <summary>
        /// Gets the whole program log cycle the user is currently running
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId);

        void CreateProgramLog(ProgramLogDTO programLog);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        /// <param name="programLog"></param>
        Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLog);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        /// <param name="programLog"></param>
        Task DeleteProgramLog(string userId, ProgramLogDTO programLog);

        #endregion

        #region ProgramLogWeek Services

        /// <summary>
        /// Gets the current active program log for this present week
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogWeekDTO> GetCurrentProgramLogWeekByUserId(string userId, int programLogId);

        #endregion

        #region ProgramLogDay Services

        /// <summary>
        /// Gets a program log day overview for a given user on a given date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date);

        /// <summary>
        /// Gets the present day program log for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId, int programLogId);


        #endregion

        #region ProgramLogExercise Services

        /// <summary>
        /// Creates a new program exercise for a specific log
        /// </summary>
        /// <param name="programLogExercise"></param>
        /// <returns></returns>
        void CreateProgramLogExercise(ProgramLogExerciseDTO programLogExercise);

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
        void DeleteProgramLogExercise(int programLogExerciseId);


        #endregion
    }
}