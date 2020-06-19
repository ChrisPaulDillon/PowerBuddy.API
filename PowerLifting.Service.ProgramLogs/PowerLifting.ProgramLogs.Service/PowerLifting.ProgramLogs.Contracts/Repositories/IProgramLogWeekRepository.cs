using System;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogWeekRepository
    {
        Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date);
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
        Task<ProgramLogWeek> GetProgramLogWeekByProgramLogIdAndDate(int programLogId, DateTime date);
    }
}