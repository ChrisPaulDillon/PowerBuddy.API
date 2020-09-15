using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Services.ProgramLog
{
    public interface IProgramLogService
    {
        Task<bool> IsProgramLogAlreadyActive(string userId);
    }
}
