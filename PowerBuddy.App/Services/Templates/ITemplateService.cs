using System;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.Templates;

namespace PowerBuddy.App.Services.Templates
{
    public interface ITemplateService
    {
        Task<TemplateProgramExtendedDto> GetTemplateProgramById(int templateProgramId);
        void AddTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded);
    }
}
