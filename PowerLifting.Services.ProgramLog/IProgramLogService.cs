using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerLifting.Services.ProgramLog
{
    public interface IProgramLogService
    {
        Task<bool> IsProgramLogAlreadyActive(string userId);
    }
}
