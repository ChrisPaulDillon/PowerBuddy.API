using System;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogWeekRepository : IRepositoryBase<ProgramLogWeek>
    {
        Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date);
        Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId);
        Task<ProgramLogWeek> GetProgramLogWeekByProgramLogIdAndDate(int programLogId, DateTime date);
    }
}