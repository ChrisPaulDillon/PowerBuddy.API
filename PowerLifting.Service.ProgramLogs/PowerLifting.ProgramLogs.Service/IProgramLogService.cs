using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogService
    {
        #region ProgramLog Services

        /// <summary>
        /// Gets all program log to show to the user what their workout will be
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProgramLogStatDTO>> GetAllProgramLogsByUserId(string userId);

        /// <summary>
        /// Gets the most recent / active program log of a given user
        /// </summary>
        Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId);

        /// <summary>
        /// Creates a new program log from scratch
        /// </summary>
        Task<ProgramLog> CreateProgramLogFromScratch(CProgramLogDTO programLog, string userId);

        /// <summary>
        /// Creates a new program log based on the selected program templates details and what days
        /// the program is to be carried out on
        /// </summary>
        Task<ProgramLog> CreateProgramLogFromTemplate(string userId, TemplateProgramDTO templateProgram, IEnumerable<LiftingStatDTO> liftingStats, DaySelected daySelected);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        /// <param name="programLog"></param>
        Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLog);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        Task<bool> DeleteProgramLog(string userId, int programLogId);

        #endregion

        #region ProgramLogWeek Services

        Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date);

        #endregion
    }
}