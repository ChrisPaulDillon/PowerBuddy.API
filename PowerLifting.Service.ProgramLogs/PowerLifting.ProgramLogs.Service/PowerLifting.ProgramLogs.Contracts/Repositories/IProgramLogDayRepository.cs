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
        /// Creates a new program day if its within the confinements of the program week
        /// </summary>
        /// <param name="programLogDay"></param>
        void CreateProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Updates a given Program log day, this could be a comment etc
        /// </summary>
        /// <param name="programLogDay"></param>
        void UpdateProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Deletes a program day off the program week
        /// </summary>
        /// <param name="programLogDay"></param>
        void DeleteProgramLogDay(ProgramLogDay programLogDay);

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);
    }
}