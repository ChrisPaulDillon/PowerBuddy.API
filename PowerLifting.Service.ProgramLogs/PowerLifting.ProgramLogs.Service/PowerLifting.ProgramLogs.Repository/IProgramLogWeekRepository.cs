using System;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Repository
{
    public interface IProgramLogWeekRepository
    {
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
        Task<ProgramLogWeek> GetProgramLogWeekByProgramLogIdAndDate(int programLogId, DateTime date);
    }
}