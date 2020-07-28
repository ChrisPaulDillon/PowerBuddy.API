using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogDayService
    {
        /// <summary>
        /// Gets the program Log Day by Id
        /// </summary>
        Task<ProgramLogDay> GetProgramLogDayById(string userId, int programLogDayId);

        /// <summary>
        /// Gets a program log day overview for a given user on a given date regardless of program log 
        /// </summary>
        Task<ProgramLogDayDTO> GetProgramLogDayByDate(string userId, DateTime date);

        /// <summary>
        /// Gets a program log day overview for a given user on a given date
        /// </summary>
        Task<ProgramLogDayDTO> GetProgramLogDayByProgramLogId(string userId, int programLogId, DateTime date);

        /// <summary>
        /// Gets the upcoming workout closest to the given date
        /// </summary>
        Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, DateTime date);

        /// <summary>
        /// Creates a new program log day, used for customising program logs
        /// </summary>
        Task<ProgramLogDay> CreateProgramLogDay(string userId, ProgramLogDayDTO programLogDay);

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);

        /// <summary>
        /// Deletes a programLog day
        /// </summary>
        Task<bool> DeleteProgramLogDay(string userId, int programLogDayId);
    }
}
