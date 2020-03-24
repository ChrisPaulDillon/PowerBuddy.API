using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;

namespace Powerlifting.Services.Service
{
    public class ProgramLogService : ServiceBase<ProgramLog>, IProgramLogService
    {
        public ProgramLogService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {

        }

        public async Task<IEnumerable<ProgramLog>> GetAllProgramLogs()
        {
            return await PowerliftingContext.Set<ProgramLog>().Include(j => j.ProgramType).Include(k => k.ExeciseMarkups).ToListAsync();
        }

        public async Task<ProgramLog> GetProgramLogById(int id)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == id).Include(j => j.ProgramType).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProgramLog>> GetActiveProgramLogs()
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.EndDate < DateTime.Now).Include(j => j.ProgramType).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                ToListAsync();
        }


        public void UpdateProgramLog(ProgramLog programLog)
        {
            Update(programLog);
        }

        public void DeleteProgramLog(ProgramLog programLog)
        {
            Delete(programLog);
        }

    }
}
