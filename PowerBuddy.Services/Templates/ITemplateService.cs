using System;
using System.Threading.Tasks;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.Templates
{
    public interface ITemplateService
    {
        Task<TemplateProgram> GetTemplateProgramById(int templateProgramId);
        void AddTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded);
    }
}
