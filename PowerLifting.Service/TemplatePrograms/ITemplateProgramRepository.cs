﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.TemplatePrograms.Model;
using PowerLifting.Services;

namespace PowerLifting.Service.TemplatePrograms
{
    public interface ITemplateProgramRepository : IRepositoryBase<TemplateProgram>
    {
        /// <summary>
        /// Gets a top level view of all the template programs such as program name, difficulty etc.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TemplateProgram>> GetAllTemplatePrograms();
        Task<TemplateProgram> GetTemplateProgramById(int programTemplateId);
        Task<TemplateProgram> GetTemplateProgramByName(string programType);
        Task<TemplateProgram> CreateTemplateProgram(TemplateProgram programType);
    }
}
