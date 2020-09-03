using PowerLifting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.Services.ProgramLog
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly PowerLiftingContext _context;

        public ProgramLogService(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> IsProgramLogAlreadyActive(string userId)
        {
            var isProgramLogActive = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.UserId == userId && x.Active == true);

            if (isProgramLogActive) throw new ProgramLogAlreadyActiveException();

            return isProgramLogActive;
        }
    }
}
