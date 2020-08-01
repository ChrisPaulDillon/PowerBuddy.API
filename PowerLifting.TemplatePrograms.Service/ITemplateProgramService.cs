﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.TemplatePrograms.Service
{
    public interface ITemplateProgramService
    {
        /// <summary>
        /// Gets a top level view of all program templates such as program title, difficulty, number of weeks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms();

        /// <summary>
        /// Gets the template program by Id
        /// </summary>
        Task<TemplateProgramDTO> GetTemplateProgramById(int programTemplateId);

        /// <summary>
        /// Gets template program name
        /// </summary>
        Task<string> GetTemplateProgramNameById(int templateProgramId);

        /// <summary>
        /// Creates a new program template, possibly to be used by an admin or custom program creation
        /// </summary>
        Task<TemplateProgramDTO> CreateTemplateProgram(TemplateProgramDTO programTemplateDTO);
    }
}