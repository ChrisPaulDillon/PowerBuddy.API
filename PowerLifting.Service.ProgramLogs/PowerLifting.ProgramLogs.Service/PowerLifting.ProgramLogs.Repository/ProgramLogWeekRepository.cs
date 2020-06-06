using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.ProgramLogs.Contracts.Repositories;
using AutoMapper;
using PowerLifting.Entity.ProgramLogs.DTO;
using AutoMapper.QueryableExtensions;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogWeekRepository : RepositoryBase<ProgramLogWeek>, IProgramLogWeekRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogWeekRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date)
        {
            //var currentWeek = DateHelper.Instance.GetWeekRangeOfCurrentWeek();
            return await PowerliftingContext.Set<ProgramLogWeek>().AsNoTracking()
                .Where(x => x.UserId == userId && x.StartDate >= date.Date && date.Date <= x.EndDate)
                .Include(k => k.ProgramLogDays)
                .ThenInclude(e => e.ProgramLogExercises)
                .ThenInclude(x => x.ProgramLogRepSchemes)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogWeek> GetProgramLogWeekById(int programLogWeekId)
        {
            return await PowerliftingContext.Set<ProgramLogWeek>().Where(x => x.ProgramLogWeekId == programLogWeekId)
                                                                        .Include(k => k.ProgramLogDays)
                                                                        .ThenInclude(e => e.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }

        public async Task<ProgramLogWeek> GetProgramLogWeekByProgramLogIdAndDate(int programLogId, DateTime date)
        {
            return await PowerliftingContext.Set<ProgramLogWeek>().Where(x => x.ProgramLogId == programLogId
                                                                         && x.StartDate >= date.Date
                                                                         && date.Date <= x.EndDate)
                                                                        .Include(k => k.ProgramLogDays)
                                                                        .ThenInclude(e => e.ProgramLogExercises)
                                                                        .ThenInclude(x => x.ProgramLogRepSchemes).FirstOrDefaultAsync();
        }
    }
}
