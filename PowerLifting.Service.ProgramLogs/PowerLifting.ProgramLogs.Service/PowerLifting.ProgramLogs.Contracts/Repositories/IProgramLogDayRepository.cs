﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogDayRepository
    {
        Task<ProgramLogDayDTO> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected);

        /// <summary>
        /// Gets a Program Log Day by a given Id
        /// </summary>
        Task<ProgramLogDayDTO> GetProgramLogDayById(int programLogDayId);

        /// <summary>
        /// Gets the closest program log day to a given date
        /// </summary>
        Task<ProgramLogDayDTO> GetClosestProgramLogDayToDate(int programLogWeekId, string userId, DateTime date);

        /// <summary>
        /// Creates a new program day if its within the confinements of the program week
        /// </summary>
        Task<ProgramLogDay> CreateProgramLogDay(ProgramLogDayDTO programLogDay);

        /// <summary>
        /// Updates a given Program log day, this could be a comment etc
        /// </summary>
        Task<bool> UpdateProgramLogDay(ProgramLogDayDTO programLogDay);

        /// <summary>
        /// Deletes a program day off the program week
        /// </summary>
        Task<bool> DeleteProgramLogDay(ProgramLogDayDTO programLogDay);

        /// <summary>
        /// Gets all the users program log dates
        /// for calendar population
        /// </summary>
        Task<IEnumerable<DateTime>> GetAllUserProgramLogDates(string userId);
    }
}