using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.ProgramLogs.Contracts.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Entity.ProgramLogs.DTO;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogRepository : RepositoryBase<ProgramLog>, IProgramLogRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId)
                                                                        .Include(x => x.ProgramLogWeeks)
                                                                        .ThenInclude(x => x.ProgramLogDays)
                                                                        .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                                                                        .ToListAsync();
        }

        public async Task<ProgramLog> GetProgramLogByUserId(string userId)
        {
            var programLog = await PowerliftingContext.Set<ProgramLog>().Where(x => x.UserId == userId && x.NoOfWeeks > 1)
                                                                         .OrderBy(x => x.StartDate)
                                                                         .Include(x => x.ProgramLogWeeks)
                                                                         .ThenInclude(x => x.ProgramLogDays)
                                                                         .ThenInclude(x => x.ProgramLogExercises)
                                                                         .ThenInclude(x => x.ProgramLogRepSchemes)
                                                                         .Include(x => x.ProgramLogWeeks)
                                                                         .ThenInclude(x => x.ProgramLogDays)
                                                                         .ThenInclude(x => x.ProgramLogExercises)
                                                                         .ThenInclude(x => x.Exercise)
                                                                         .FirstAsync();

            //programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo).Select(x => x.ProgramLogDays.OrderBy(x => x.DayNo));
            programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo);
            return programLog;
        }


        public async Task<ProgramLog> GetProgramLogById(int programLogId)
        {
            return await PowerliftingContext.Set<ProgramLog>().Where(x => x.ProgramLogId == programLogId).FirstOrDefaultAsync();
        }

        public async Task CreateProgramLog(ProgramLog programLog)
        {
            await Create(programLog);
        }

        public async Task<bool> UpdateProgramLog(ProgramLog log)
        {
            return await Update(log);
        }

        public async Task<bool> DeleteProgramLog(ProgramLog log)
        {
            return await Delete(log);
        }

        public async Task<bool> DoesProgramLogAfterTodayExist(string userId)
        {
            return await PowerliftingContext.Set<ProgramLog>().AnyAsync(x => x.StartDate >= DateTime.Now && x.UserId == userId);
        }
    }
}
