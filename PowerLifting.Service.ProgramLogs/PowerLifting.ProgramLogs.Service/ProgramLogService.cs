using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service.Util;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> UpdateProgramLog(ProgramLogDTO programLogDTO, string userId)
        {
            var doesLogExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.ProgramLogId == programLogDTO.ProgramLogId && x.UserId == userId);

            if (!doesLogExist) throw new ProgramLogNotFoundException();

            _context.Update(programLogDTO);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLog(int programLogId, string userId)
        {

        }

        public async Task<ProgramLogWeekDTO> GetProgramLogWeekBetweenDate(DateTime date, string userId)
        {

        }
    }
}