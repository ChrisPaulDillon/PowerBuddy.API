using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogRepository : IRepositoryBase<ProgramLog>
    {
        /// <summary>
        /// Gets all the program logs a user owns
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProgramLog>> GetAllProgramLogsByUserId(string userId);

        /// <summary>
        /// Gets a given program log by id, presumably the one the user is currently on
        /// </summary>
        /// <param name="programLogId"></param>
        /// <returns></returns>
        Task<ProgramLog> GetProgramLogById(int programLogId);

        /// <summary>
        /// Creates a new program log for the user
        /// </summary>
        /// <param name="programLog"></param>
        /// <returns></returns>
        Task CreateProgramLog(ProgramLog programLog);

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