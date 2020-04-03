using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogs.DTO;

namespace Powerlifting.Services.ProgramLogs
{
    public interface IProgramLogService
    {

        /// <summary>
        /// Gets the current dates program log to show to the user what their workout will be 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDTO> GetTodaysProgramLogByUserId(string userId);

        /// <summary>
        /// Gets the weekly overview of the program cycle the user is running
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDTO> GetWeeklyProgramLogByUserId(string userId);

        /// <summary>
        /// Gets the whole program log cycle the user is currently running
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId);

        /// <summary>
        /// Gets the entire program log that is to be updated
        /// </summary>
        /// <param name="programLogId"></param>
        /// <returns></returns>
        Task<ProgramLogDTO> GetProgramLogByProgramLogId(int programLogId);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        /// <param name="programLog"></param>
        void UpdateProgramLog(string userId, ProgramLogDTO programLog);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        /// <param name="programLog"></param>
        void DeleteProgramLog(string userId, ProgramLogDTO programLog);
    }
}
