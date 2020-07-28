using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogRepository : IProgramLogRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId)
        {
            return await _context.Set<ProgramLog>().Where(x => x.UserId == userId)
                                                                        .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                                                                        .AsNoTracking()
                                                                        .ToListAsync();
        }

        public async Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId)
        {
            var programLog = await _context.ProgramLog.Where(x => x.UserId == userId && x.Active == true)
                                                                         .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                                                                         .AsNoTracking()
                                                                         .FirstOrDefaultAsync();

            //programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo).Select(x => x.ProgramLogDays.OrderBy(x => x.DayNo));
            if (programLog != null)
            {
                programLog.ProgramLogWeeks = programLog.ProgramLogWeeks.OrderBy(x => x.WeekNo);
                return programLog;
            }
            return null;
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

        public async Task<ProgramLog> CreateProgramLog(CProgramLogDTO programLogDTO)
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

        public async Task<string> DoesProgramLogExist(int programLogId)
        {
            return await _context.Set<ProgramLog>()
                .AsNoTracking()
                .Where(x => x.ProgramLogId == programLogId)
                .Select(x => x.UserId)
                .FirstOrDefaultAsync();
        }
    }
}
