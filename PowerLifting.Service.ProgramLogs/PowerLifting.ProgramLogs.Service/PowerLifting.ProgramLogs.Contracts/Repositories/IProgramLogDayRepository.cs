using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogDayRepository : IRepositoryBase<ProgramLogDay>
    {
        Task<ProgramLogDayDTO> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected);

        /// <summary>
        /// Gets a Program Log Day by a given Id
        /// </summary>
        Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId);

        /// <summary>
        /// Gets the closest program log day to a given date
        /// </summary>
        Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(string userId, int programLogId, DateTime date);

        /// <summary>
        /// Creates a new program day if its within the confinements of the program week
        /// </summary>
        Task CreateProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Updates a given Program log day, this could be a comment etc
        /// </summary>
        Task<bool> UpdateProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Deletes a program day off the program week
        /// </summary>
        Task<bool> DeleteProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);
    }
}