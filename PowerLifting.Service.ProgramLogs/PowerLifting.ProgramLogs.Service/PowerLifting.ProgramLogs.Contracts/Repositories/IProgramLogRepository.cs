using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogRepository : IRepositoryBase<ProgramLog>
    {
        /// <summary>
        /// Gets all the program logs a user owns
        /// </summary>
        Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId);

        /// <summary>
        /// Gets the users current program log
        /// </summary>
        Task<ProgramLog> GetProgramLogByUserId(string userId);

        /// <summary>
        /// Gets a given program log by id, presumably the one the user is currently on
        /// </summary>
        Task<ProgramLog> GetProgramLogById(int programLogId);

        /// <summary>
        /// Determines if the user already has an active program log
        /// </summary>
        Task<bool> DoesProgramLogAfterTodayExist(string userId);

        /// <summary>
        /// Creates a new program log for the user
        /// </summary>
        Task CreateProgramLog(ProgramLog programLog);

        /// <summary>
        /// Updates the program log accordingly
        /// </summary>
        Task<bool> UpdateProgramLog(ProgramLog log);

        /// <summary>
        /// Allows a user to delete the current log selected
        /// </summary>
        Task<bool> DeleteProgramLog(ProgramLog log);
    }
}