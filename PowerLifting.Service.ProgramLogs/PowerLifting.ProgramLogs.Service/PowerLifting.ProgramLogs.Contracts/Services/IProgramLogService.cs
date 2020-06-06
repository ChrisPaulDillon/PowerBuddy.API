using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.ProgramLogs.Contracts.Services
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
        ProgramLogDTO CreateProgramLogFromTemplate(TemplateProgramDTO templateProgram, IEnumerable<LiftingStatDTO> liftingStats, DaySelected daySelected);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        /// <param name="programLog"></param>
        Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLog);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        /// <param name="programLog"></param>
        Task DeleteProgramLog(string userId, int programLogId);

        #endregion

        #region ProgramLogWeek Services

        Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date);

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
    }
}