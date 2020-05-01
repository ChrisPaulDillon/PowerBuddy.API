using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Model;

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
        /// Gets the most recent / active program log of a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDTO> GetProgramLogByUserId(string userId);

        /// <summary>
        /// Creates a new generic program log
        /// </summary>
        /// <param name="programLog"></param>
        /// <returns></returns>
        Task CreateProgramLog(ProgramLogDTO programLog);

        /// <summary>
        /// Creates a new program log based on the selected program templates details and what days
        /// the program is to be carried out on
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        Task CreateProgramLogFromTemplate(int templateId, DaySelected daySelected);

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
        Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId);

        /// <summary>
        /// Creates a new program log day, used for customising program logs
        /// </summary>
        /// <param name="programLogDay"></param>
        Task CreateProgramLogDay(ProgramLogDayDTO programLogDay);


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

        #region ProgramLogRepSchemes

        /// <summary>
        /// Create a new program log rep scheme, assuming the user has done
        /// an additional set etc
        /// </summary>
        /// <param name="programLogRepSchemeDTO"></param>
        /// <returns></returns>
        void CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Allows a user to update weight lifted, comment etc on a given program rep
        /// </summary>
        /// <param name="programLogRepSchemeDTO"></param>
        /// <returns></returns>
        Task UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Deletes a program log rep scheme, assuming the user did not finish a prescribed set?
        /// </summary>
        /// <param name="programLogRepSchemeDTO"></param>
        /// <returns></returns>
        Task DeleteProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        #endregion
    }
}