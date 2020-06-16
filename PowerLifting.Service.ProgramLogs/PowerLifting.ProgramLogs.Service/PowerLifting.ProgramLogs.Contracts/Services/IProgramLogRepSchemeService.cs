﻿using System;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;

namespace PowerLifting.ProgramLogs.Contracts.Services
{
    public interface IProgramLogRepSchemeService
    {
        /// <summary>
        /// Create a new program log rep scheme, assuming the user has done
        /// an additional set etc
        /// </summary>
        /// <param name="programLogRepSchemeDTO"></param>
        /// <returns></returns>
        void CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Allows a user to update weight lifted, comment etc on a given program rep
        /// </summary>
        /// <param name="programLogRepSchemeDTO"></param>
        /// <returns></returns>
        Task UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO);

        /// <summary>
        /// Deletes a program log rep scheme, assuming the user did not finish a prescribed set?
        /// </summary>
        /// <param name="programLogRepSchemeId"></param>
        /// <returns></returns>
        Task DeleteProgramLogRepScheme(int programLogRepSchemeId);
    }
}