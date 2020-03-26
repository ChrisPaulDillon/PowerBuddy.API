using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ServiceWrappers;

namespace Powerlifting.Services.ProgramLogs
{
    public class ProgramLogService : ServiceBase<ProgramLog>, IProgramLogService
    {
        private IMapper _mapper;

        public ProgramLogService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogs()
        {
            var logs = await PowerliftingContext.Set<ProgramLog>().Include(j => j.ProgramTemplate).Include(k => k.ExeciseMarkups).ToListAsync();
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogById(int id)
        {
            var log = await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == id).Include(j => j.ProgramTemplate).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                FirstOrDefaultAsync();
            var logDTO = _mapper.Map<ProgramLogDTO>(log);
            return logDTO;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetActiveProgramLogs()
        {
            var logs =  await PowerliftingContext.Set<ProgramLog>().Where(x => x.EndDate < DateTime.Now).Include(j => j.ProgramTemplate).
                                                                                                Include(k => k.ExeciseMarkups.Select(c => c.IndividualSets)).
                                                                                                ToListAsync();
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
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
