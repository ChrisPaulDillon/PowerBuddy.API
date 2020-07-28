using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.ProgramLogs.Service.Wrapper;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;
        private readonly UserManager<User> _userManager;

        public ProgramLogService(IProgramLogWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ProgramLogStatDTO>> GetAllProgramLogsByUserId(string userId)
        {
            var programLogStats = (List<ProgramLogDTO>)await _repo.ProgramLog.GetAllProgramLogsByUserId(userId);

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
            var programLogDTO = await _repo.ProgramLog.GetActiveProgramLogByUserId(userId);
            if (programLogDTO == null) throw new ProgramLogNotFoundException();
            return programLogDTO;
        }

        public async Task<ProgramLog> CreateProgramLogFromScratch(CProgramLogDTO programLog, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var startDate = programLog.StartDate;

            for (int i = 1; i < programLog.NoOfWeeks + 1; i++)
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

                for (int j = 0; j < programLog.NoOfDays; j++)
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

            return await _repo.ProgramLog.CreateProgramLog(programLog);
        }

        public async Task<ProgramLog> CreateProgramLogFromTemplate(string userId, TemplateProgramDTO templateProgram, IEnumerable<LiftingStatDTO> liftingStats, DaySelected daySelected)
        {
            var doesExist = await _repo.ProgramLog.DoesProgramLogAfterTodayExist(userId);
            if (doesExist) throw new ProgramLogAlreadyActiveException();

            daySelected = CountDaysSelected(daySelected);
            var newProgramLog = CreateProgramLog(templateProgram, daySelected, liftingStats.ToList(), userId);
            return await _repo.ProgramLog.CreateProgramLog(newProgramLog);
        }

        private static DaySelected CountDaysSelected(DaySelected ds)
        {
            ds.ProgramOrder = new Dictionary<int, string>();

            var startingDay = ds.StartDate.DayOfWeek;
            var startingNo = (int)ds.StartDate.DayOfWeek;

            var counter = 1;
            ds.ProgramOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                if (day == DayOfWeek.Monday)
                {
                    if (ds.Monday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Tuesday)
                {
                    if (ds.Tuesday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Wednesday)
                {
                    if (ds.Wednesday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Thursday)
                {
                    if (ds.Thursday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Friday)
                {
                    if (ds.Friday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Saturday)
                {
                    if (ds.Saturday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Sunday)
                {
                    if (ds.Sunday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
            }

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
            {
                var dayNo = (int)day;

                if (dayNo >= startingNo) //Once we get to the day we originally started on, stop
                    break;

                if (day == DayOfWeek.Monday)
                {
                    if (ds.Monday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Tuesday)
                {
                    if (ds.Tuesday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Wednesday)
                {
                    if (ds.Wednesday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Thursday)
                {
                    if (ds.Thursday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Friday)
                {
                    if (ds.Friday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Saturday)
                {
                    if (ds.Saturday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if (day == DayOfWeek.Sunday)
                {
                    if (ds.Sunday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
            }
            return ds;
        }

        private ProgramLogDTO CreateProgramLog(TemplateProgramDTO tp, DaySelected ds, List<LiftingStatDTO> liftingStats, string userId)
        {
            var log = new ProgramLogDTO
            {
                TemplateProgramId = tp.TemplateProgramId,
                UserId = userId,
                Monday = ds.Monday,
                Tuesday = ds.Tuesday,
                Wednesday = ds.Wednesday,
                Thursday = ds.Thursday,
                Friday = ds.Friday,
                Saturday = ds.Saturday,
                Sunday = ds.Sunday,
                StartDate = ds.StartDate,
                EndDate = ds.StartDate.AddDays(tp.NoOfWeeks * 7),
                NoOfWeeks = tp.NoOfWeeks,
                Active = true,
                ProgramLogWeeks = GenerateProgramWeekDates(ds, tp, userId, liftingStats)
            };
            return log;
        }

        private List<ProgramLogWeekDTO> GenerateProgramWeekDates(DaySelected ds, TemplateProgramDTO tp, string userId, List<LiftingStatDTO> liftingStats)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeekWithDays = CreateProgramLogWeek(templateWeek, ds, userId, liftingStats);
                listOfProgramWeeks.Add(programLogWeekWithDays);
                ds.StartDate = ds.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        private static ProgramLogWeekDTO CreateProgramLogWeek(TemplateWeekDTO templateWeek, DaySelected ds, string userId, List<LiftingStatDTO> liftingStats)
        {
            var programLogWeek = new ProgramLogWeekDTO()
            {
                StartDate = ds.StartDate,
                EndDate = ds.StartDate.AddDays(7),
                WeekNo = templateWeek.WeekNo,
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDayDTO>()
            };

            var startDate = programLogWeek.StartDate;
            foreach (var templateDay in templateWeek.TemplateDays)
            {
                var dayOfWeek = ds.ProgramOrder[templateDay.DayNo];
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Monday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Tuesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Wednesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Thursday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Friday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Saturday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Sunday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
            }
            return programLogWeek;
        }

        private static ProgramLogDayDTO GenerateProgramLogDay(DayOfWeek day, TemplateDayDTO templateDay, DateTime startDate, List<LiftingStatDTO> liftingStats)
        {
            var daysUntilSpecificDay = ((int)day - (int)startDate.DayOfWeek + 7) % 7;
            var nextDate = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDayDTO()
            {
                Date = nextDate,
                ProgramLogExercises = CreateProgramLogExercises(templateDay, liftingStats)
            };
            return programLogDay;
        }

        private static IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercises(TemplateDayDTO templateDay, List<LiftingStatDTO> liftingStats)
        {
            var programLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = new ProgramLogExerciseDTO()
                {
                    NoOfSets = temExercise.NoOfSets,
                    ExerciseId = temExercise.ExerciseId,
                    ProgramLogRepSchemes = new List<ProgramLogRepSchemeDTO>()
                };
                var user1RMOnLift = liftingStats.SingleOrDefault(x => x.ExerciseId == temExercise.ExerciseId);

                foreach (var temReps in temExercise.TemplateRepSchemes)
                {
                    var programRepSchema = GenerateProgramLogRepScheme("PERCENTAGE", (double)(user1RMOnLift.Weight), temReps);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                }
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        private static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string weightProgressionType, double user1RM, TemplateRepSchemeDTO templateRepScheme)
        {
            var weightToLift = 0.00M;

            if (Enum.TryParse(weightProgressionType, out WeightProgressionTypeEnum weightProgressionTypeEnum))
            {
                switch (weightProgressionTypeEnum)
                {
                    case WeightProgressionTypeEnum.PERCENTAGE:
                        var percent = templateRepScheme.Percentage / 100;
                        weightToLift = Convert.ToDecimal(user1RM * percent);
                        break;
                    case WeightProgressionTypeEnum.INCREMENTAL:
                        break;
                }
            }

            return new ProgramLogRepSchemeDTO()
            {
                SetNo = templateRepScheme.SetNo,
                NoOfReps = templateRepScheme.NoOfReps,
                Percentage = templateRepScheme.Percentage,
                WeightLifted = weightToLift,
                AMRAP = templateRepScheme.AMRAP,
            };
        }

        public async Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);

            if (programLog == null) throw new ProgramLogNotFoundException();
            if (programLog.UserId != userId)
            {
                throw new UnauthorisedUserException("UserId does match the user associated with this program log!");
            }

            _mapper.Map(programLogDTO, programLog);
            var result = await _repo.ProgramLog.UpdateProgramLog(programLogDTO);
            return programLogDTO;
        }

        public async Task<bool> DeleteProgramLog(string userId, int programLogId)
        {
            var doesProgramLogExist = await _repo.ProgramLog.DoesProgramLogExist(programLogId);

            if (string.IsNullOrWhiteSpace(doesProgramLogExist)) throw new ProgramLogNotFoundException();

            if (doesProgramLogExist != userId)
            {
                throw new UnauthorisedUserException("UserId does match the user associated with this program log!");
            }

            return await _repo.ProgramLog.DeleteProgramLog(new ProgramLogDTO() { ProgramLogId = programLogId });
        }

        public async Task<ProgramLogWeekDTO> GetProgramLogWeekByUserIdAndDate(string userId, DateTime date)
        {
            //_validator.ValidateProgramLogWeekId(programLogWeekId);
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekByUserIdAndDate(userId, date);
            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}