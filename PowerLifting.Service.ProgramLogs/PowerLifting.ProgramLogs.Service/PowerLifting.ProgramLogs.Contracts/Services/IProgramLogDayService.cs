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
        Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date);

        /// <summary>
        /// Gets the upcoming workout closest to the given date
        /// </summary>
        Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, int programLogId, DateTime date);

        /// <summary>
        /// Gets the program Log Day by Id
        /// </summary>
        Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId);

        /// <summary>
        /// Creates a new program log day, used for customising program logs
        /// </summary>
        Task<ProgramLogDayDTO> CreateProgramLogDay(ProgramLogDayDTO programLogDay);

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);
    }
}
