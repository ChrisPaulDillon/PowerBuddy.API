using System.Threading.Tasks;
using PowerLifting.Service;
using Powerlifting.Services.ProgramLogs;

namespace PowerLifting.Services.ProgramLogs
{
    public interface IProgramLogRepository : IRepositoryBase<ProgramLog>
    {
        /// <summary>
        /// Gets the current dates program log to show to the user what their workout will be 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLog> GetTodaysProgramLogByUserId(string userId);

        /// <summary>
        /// Gets the weekly overview of the program cycle the user is running
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLog> GetWeeklyProgramLogByUserId(string userId);

        /// <summary>
        /// Gets the whole program log cycle the user is currently running
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLog> GetActiveProgramLogByUserId(string userId);

        /// <summary>
        /// Used to grab the program log for updating 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLog> GetProgramLogByProgramLogId(int programLogId);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        /// <param name="programLog"></param>
        void UpdateProgramLog(ProgramLog log);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        /// <param name="programLog"></param>
        void DeleteProgramLog(ProgramLog log);
    }
}
