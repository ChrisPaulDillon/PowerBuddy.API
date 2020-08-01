using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogService
    {
        Task<IEnumerable<ProgramLogStatDTO>> GetAllProgramLogsByUserId(string userId);

        Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId);

        Task<ProgramLog> CreateProgramLogFromScratch(CProgramLogDTO programLog, string userId);

        Task<ProgramLog> CreateProgramLogFromTemplate(string userId, TemplateProgramDTO templateProgram, IEnumerable<LiftingStatDTO> liftingStats, DaySelected daySelected);

        Task<bool> UpdateProgramLog(ProgramLogDTO programLog, string userId);

        Task<bool> DeleteProgramLog(int programLogId, string userId);

        Task<ProgramLogWeekDTO> GetProgramLogWeekBetweenDate(DateTime date, string userId);

    }
}