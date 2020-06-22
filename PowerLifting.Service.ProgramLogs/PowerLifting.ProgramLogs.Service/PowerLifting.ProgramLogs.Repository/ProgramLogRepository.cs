using Microsoft.EntityFrameworkCore;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
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
    public class ProgramLogRepository : IProgramLogRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId)
        {
            return await _context.Set<ProgramLog>().Where(x => x.UserId == userId)
                                                                        .Include(x => x.ProgramLogWeeks)
                                                                        .ThenInclude(x => x.ProgramLogDays)
                                                                        .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                                                                        .ToListAsync();
        }

        public async Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId)
        {
            var programLog = await _context.Set<ProgramLog>().Where(x => x.UserId == userId && x.NoOfWeeks > 1 && x.Active)
                                                                         .Select(x => new ProgramLogDTO()
                                                                         {
                                                                             ProgramLogId = x.ProgramLogId,
                                                                             TemplateProgramId = x.TemplateProgramId,
                                                                             Monday = x.Monday,
                                                                             Tuesday = x.Tuesday,
                                                                             Wednesday = x.Wednesday,
                                                                             Thursday = x.Thursday,
                                                                             Friday = x.Friday,
                                                                             Saturday = x.Saturday,
                                                                             Sunday = x.Sunday
                                                                         })
                                                                         .AsNoTracking()
                                                                         .FirstAsync();

            //programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo).Select(x => x.ProgramLogDays.OrderBy(x => x.DayNo));
            programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo);
            return programLog;
        }


        public async Task<ProgramLog> GetProgramLogById(int programLogId)
        {
            return await _context.Set<ProgramLog>().Where(x => x.ProgramLogId == programLogId).FirstOrDefaultAsync();
        }

        public async Task<ProgramLog> CreateProgramLog(ProgramLogDTO programLogDTO)
        {
            var programLog = _mapper.Map<ProgramLog>(programLogDTO);
            _context.Add(programLog);

            await _context.SaveChangesAsync();
            return programLog;
        }

        public async Task<bool> UpdateProgramLog(ProgramLogDTO logDTO)
        {
            var programLog = _mapper.Map<ProgramLog>(logDTO);
            _context.Update(programLog);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLog(ProgramLogDTO logDTO)
        {
            var programLog = _mapper.Map<ProgramLog>(logDTO);
            _context.Remove(programLog);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DoesProgramLogAfterTodayExist(string userId)
        {
            return await _context.Set<ProgramLog>().AnyAsync(x => x.StartDate >= DateTime.Now && x.UserId == userId);
        }
    }
}
