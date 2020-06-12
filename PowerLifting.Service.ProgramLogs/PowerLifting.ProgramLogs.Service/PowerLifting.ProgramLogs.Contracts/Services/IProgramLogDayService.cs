using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;

namespace PowerLifting.ProgramLogs.Contracts.Services
{
    public interface IProgramLogDayService
    {
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

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);
    }
}
