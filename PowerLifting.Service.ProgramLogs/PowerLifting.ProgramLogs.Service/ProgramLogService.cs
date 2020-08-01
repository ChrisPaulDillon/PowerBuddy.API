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
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service.Util;
using PowerLifting.ProgramLogs.Service.Wrapper;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;
        private readonly UserManager<User> _userManager;

        public ProgramLogService(PowerLiftingContext context, IProgramLogWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ProgramLogStatDTO>> GetAllProgramLogsByUserId(string userId)
        {
            var programLogStats = await _context.Set<ProgramLog>().Where(x => x.UserId == userId)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();

            if (programLogStats == null) throw new ProgramLogNotFoundException();

            var stats = programLogStats.Select(x => new ProgramLogStatDTO()
            {
                ProgramLogId = x.ProgramLogId,
                TemplateProgramId = x.TemplateProgramId ?? 0,
                NoOfWeeks = x.NoOfWeeks,
                UserId = x.UserId,
                Monday = x.Monday,
                Tuesday = x.Tuesday,
                Wednesday = x.Wednesday,
                Thursday = x.Thursday,
                Friday = x.Friday,
                Saturday = x.Saturday,
                Sunday = x.Sunday,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,
                DayCount = x.ProgramLogWeeks.Sum(j => j.ProgramLogDays.Count),
                ExerciseCount = x.ProgramLogWeeks.SelectMany(c => c.ProgramLogDays).SelectMany(p => p.ProgramLogExercises).Count(),
                ExerciseCompletedCount = x.ProgramLogWeeks.SelectMany(c => c.ProgramLogDays).SelectMany(p => p.ProgramLogExercises.Where(x => x.Completed)).Count(),
            });
            return stats;
        }

        public async Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId)
        {
            var programLogDTO = await _context.ProgramLog.Where(x => x.UserId == userId && x.Active)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogDTO == null) throw new ProgramLogNotFoundException();
            return programLogDTO;
        }

        public async Task<ProgramLog> CreateProgramLogFromScratch(CProgramLogDTO programLog, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var startDate = programLog.StartDate;

            for (var i = 1; i < programLog.NoOfWeeks + 1; i++)
            {
                //ds.StartDate = ds.StartDate.AddDays(7);
                var programLogWeek = new ProgramLogWeekDTO()
                {
                    StartDate = startDate,
                    EndDate = startDate.AddDays(7),
                    WeekNo = i,
                    UserId = userId,
                    ProgramLogDays = new List<ProgramLogDayDTO>()
                };

                for (var j = 0; j < programLog.NoOfDays; j++)
                {
                    if (programLog.Monday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Tuesday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Tuesday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Wednesday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Wednesday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Thursday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Thursday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Friday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Friday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Saturday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Saturday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                    else if (programLog.Sunday)
                    {
                        var daysUntilSpecificDay = ((int)DayOfWeek.Sunday - (int)startDate.DayOfWeek + 7) % 7;
                        var nextDate = startDate.AddDays(daysUntilSpecificDay);
                        var programLogDay = new ProgramLogDayDTO()
                        {
                            Date = nextDate,
                            UserId = programLogWeek.UserId
                        };
                        programLogWeek.ProgramLogDays.Add(programLogDay);
                    }
                }
                startDate = startDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            programLog.ProgramLogWeeks = listOfProgramWeeks;

            var programLogEntity = _mapper.Map<ProgramLog>(programLog);
            _context.ProgramLog.Add(programLogEntity);
            await _context.SaveChangesAsync();
            return programLogEntity;
        }

        public async Task<ProgramLog> CreateProgramLogFromTemplate(string userId, TemplateProgramDTO templateProgram, IEnumerable<LiftingStatDTO> liftingStats, DaySelected daySelected)
        {
            var doesExist = await _context.Set<ProgramLog>().AnyAsync(x => x.Active && x.UserId == userId);
            if (doesExist) throw new ProgramLogAlreadyActiveException();

            daySelected = ProgramLogHelper.CalculateDayOrder(daySelected);

            var createdLog = new ProgramLogDTO
            {
                TemplateProgramId = templateProgram.TemplateProgramId,
                UserId = userId,
                Monday = daySelected.Monday,
                Tuesday = daySelected.Tuesday,
                Wednesday = daySelected.Wednesday,
                Thursday = daySelected.Thursday,
                Friday = daySelected.Friday,
                Saturday = daySelected.Saturday,
                Sunday = daySelected.Sunday,
                StartDate = daySelected.StartDate,
                EndDate = daySelected.StartDate.AddDays(templateProgram.NoOfWeeks * 7),
                NoOfWeeks = templateProgram.NoOfWeeks,
                Active = true,
                ProgramLogWeeks = ProgramLogHelper.GenerateProgramWeekDates(daySelected, templateProgram, userId, liftingStats)
            };

            var programLog = _mapper.Map<ProgramLog>(createdLog);
            _context.Add(programLog);

            await _context.SaveChangesAsync();
            return programLog;
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
            var doesLogExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.ProgramLogId == programLogId && x.UserId == userId);

            if (!doesLogExist) throw new ProgramLogNotFoundException();

            _context.Remove(new ProgramLog() { ProgramLogId = programLogId });

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<ProgramLogWeekDTO> GetProgramLogWeekBetweenDate(DateTime date, string userId)
        {
            var programLogWeek = await _context.Set<ProgramLogWeek>()
                .Where(x => x.UserId == userId && date.Date >= x.StartDate.Date && date.Date <= x.EndDate.Date)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}