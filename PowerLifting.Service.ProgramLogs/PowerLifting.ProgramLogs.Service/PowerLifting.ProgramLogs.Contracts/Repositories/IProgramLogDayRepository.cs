﻿using System;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogDayRepository : IRepositoryBase<ProgramLogDay>
    {
        Task<ProgramLogDay> GetProgramLogDay(string userId, int programLogId, DateTime dateSelected);

        /// <summary>
        /// Used for grabbing the users present workout routine for today
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProgramLogDay> GetProgramLogTodayDay(string userId);

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
    }
}