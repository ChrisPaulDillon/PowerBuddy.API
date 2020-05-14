using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.ProgramLogs.Validator;
using PowerLifting.Service.TemplatePrograms.Exceptions;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;
        private readonly UserManager<User> _userManager;
        private readonly ProgramLogValidator _validator;

        public ProgramLogService(IRepositoryWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _validator = new ProgramLogValidator();
        }

        #region ProgramLogServices

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId)
        {
            var userProgramLogs = await _repo.ProgramLog.GetAllProgramLogsByUserId(userId);
            _validator.ValidateProgramLogsExists(userProgramLogs);

            var userProgramLogsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(userProgramLogs);
            return userProgramLogsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogByUserId(string userId)
        {
            var userProgramLog = await _repo.ProgramLog.GetProgramLogByUserId(userId);
            _validator.ValidateProgramLogExists(userProgramLog);

            var userProgramLogDTO = _mapper.Map<ProgramLogDTO>(userProgramLog);
            return userProgramLogDTO;
        }

        public async Task CreateProgramLog(ProgramLogDTO programLog)
        {
            var log = await _repo.ProgramLog.GetProgramLogById(programLog.ProgramLogId);
            _validator.ValiateProgramLogDoesNotAlreadyExist(log);

            var newProgramLog = _mapper.Map<ProgramLog>(programLog);
            _repo.ProgramLog.CreateProgramLog(newProgramLog);
        }

        private bool DoesProgramLogAlreadyExist(string userId)
        {
            return _repo.ProgramLog.DoesProgramLogAfterTodayExist(userId);
        }

        public ProgramLogDTO CreateProgramLogFromTemplate(int templateProgramId, DaySelected daySelected)
        {
            const string userId = "56dd9451-7066-41ac-8b3a-9041a676fac7";

            if (DoesProgramLogAlreadyExist(userId)) throw new ProgramLogAlreadyActiveException(); //doesnt work lul

            var tp = _repo.TemplateProgram.GetTemplateProgramById(templateProgramId);
            _validator.ValidateTemplateProgramExists(tp);

            var tec = _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(templateProgramId);

            var dayCounter = CountDaysSelected(daySelected);
            _validator.ValidateProgramLogDaysMatchTemplateDaysCount(dayCounter, tp.MaxLiftDaysPerWeek);

            var userLiftingStats = _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, 1);
            _validator.ValiateUserHasLiftingStatSetForTemplateExercises(userLiftingStats);

            var liftingStats = userLiftingStats.ToList();
            var checkLiftingStats = liftingStats.Where(item1 => tec.Any(item2 => item1.ExerciseId == item2));

            var userLiftingStatsCount = liftingStats.Count();
            var programLiftingStats = checkLiftingStats.Count();

            if (userLiftingStatsCount != programLiftingStats) throw new TemplateExercise1RMNotSetForUserException();

            var newProgramLog = CreateProgramLog(tp, daySelected, liftingStats, userId);
            var programLog = _mapper.Map<ProgramLog>(newProgramLog);
            _repo.ProgramLog.CreateProgramLog(programLog);
            return newProgramLog;
        }

        private static int CountDaysSelected(DaySelected ds)
        {
            var counter = 0;
            if (ds.Monday) counter++;
            if (ds.Tuesday) counter++;
            if (ds.Wednesday) counter++;
            if (ds.Thursday) counter++;
            if (ds.Friday) counter++;
            if (ds.Saturday) counter++;
            if (ds.Sunday) counter++;
            return counter;
        }

        private ProgramLogDTO CreateProgramLog(TemplateProgram tp, DaySelected ds, IEnumerable<LiftingStat> liftingStats, string userId)
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
                ProgramLogWeeks = GenerateProgramWeekDates(ds, tp.NoOfWeeks, userId)
            };

            log.ProgramLogWeeks = GenerateProgramExercises(tp, (List<ProgramLogWeekDTO>)log.ProgramLogWeeks, (List<LiftingStat>)liftingStats);
            return log;
        }

        private List<ProgramLogWeekDTO> GenerateProgramWeekDates(DaySelected ds, int noOfWeeks, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            for (var i = 1; i < noOfWeeks + 1; i++)
            {
                var programLogWeek = new ProgramLogWeekDTO()
                {
                    StartDate = ds.StartDate,
                    EndDate = ds.StartDate.AddDays(7),
                    WeekNumber = i,
                    UserId = userId
                };
                var programLogWeekWithDays = GenerateProgramLogDaysForWeek(programLogWeek, ds);
                listOfProgramWeeks.Add(programLogWeekWithDays);
                ds.StartDate = ds.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        private static ProgramLogWeekDTO GenerateProgramLogDaysForWeek(ProgramLogWeekDTO programLogWeek, DaySelected ds)
        {
            var listOfProgramDays = new List<ProgramLogDayDTO>();
            var startDate = programLogWeek.StartDate;
            if (ds.Monday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Monday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Tuesday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Tuesday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Wednesday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Wednesday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Thursday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Thursday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Friday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Friday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Saturday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Saturday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Sunday)
            {
                var programLogDay = GenerateProgramLogDay(DayOfWeek.Sunday, startDate);
                programLogDay.UserId = programLogWeek.UserId;
                listOfProgramDays.Add(programLogDay);
            }
            programLogWeek.ProgramLogDays = listOfProgramDays;
            return programLogWeek;
        }

        private static ProgramLogDayDTO GenerateProgramLogDay(DayOfWeek day, DateTime startDate)
        {
            var daysUntilSpecificDay = ((int)day - (int)startDate.DayOfWeek + 7) % 7;
            var nextMon = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDayDTO()
            {
                Date = nextMon,
                DayOfWeek = day.ToString(),
                ProgramLogExercises = new List<ProgramLogExerciseDTO>()
            };
            return programLogDay;
        }

        private static List<ProgramLogWeekDTO> GenerateProgramExercises(TemplateProgram templateProgram, List<ProgramLogWeekDTO> programLogWeeks,
                                                                    IReadOnlyCollection<LiftingStat> liftingStats)
        {
            foreach (var week in templateProgram.TemplateWeeks)
            {
                foreach (var logWeek in programLogWeeks)
                {
                    foreach (var day in week.TemplateDays)
                    {
                        foreach (var logDay in logWeek.ProgramLogDays)
                        {
                            foreach (var temExercise in day.TemplateExercises)
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
                                    var programRepSchema = GenerateProgramLogRepScheme(temExercise.RepSchemeType, user1RMOnLift.Weight, temReps);
                                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                                }
                                logDay.ProgramLogExercises.Add(programLogExercise);
                            }
                        }
                    }
                }
            }
            return programLogWeeks;
        }

        private static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string repSchemeType, double user1RM, TemplateRepScheme repSchema)
        {
            var weightToLift = 0.0;
            if (repSchemeType == Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE))
            {
                var percent = repSchema.Percentage / 100;
                weightToLift = Convert.ToDouble(user1RM * percent);
            }
            if (repSchemeType == Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL))
            {

            }

            return new ProgramLogRepSchemeDTO()
            {
                SetNo = repSchema.SetNo,
                NoOfReps = repSchema.NoOfReps,
                Percentage = repSchema.Percentage,
                WeightLifted = weightToLift
            };
        }

        public async Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);

            if (programLog.UserId != userId)
            {
                throw new UserDoesNotMatchProgramLogException("UserId does match the user associated with this program log!");
            }

            _validator.ValidateProgramLogExists(programLog);

            _mapper.Map(programLogDTO, programLog);
            _repo.ProgramLog.UpdateProgramLog(programLog);
            return programLogDTO;
        }

        public async Task DeleteProgramLog(string userId, int programLogId)
        {
            _validator.ValidateProgramLogId(programLogId);
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogId);

            if (programLog.UserId != userId)
            {
                throw new UserDoesNotMatchProgramLogException("UserId does match the user associated with this program log!");
            }

            _validator.ValidateProgramLogExists(programLog);

            _repo.ProgramLog.DeleteProgramLog(programLog);
        }

        #endregion

        #region ProgramLogWeekServices

        public async Task<ProgramLogWeekDTO> GetCurrentProgramLogWeekByUserId(string userId)
        {
            //_validator.ValidateProgramLogWeekId(programLogWeekId);
            var programLogWeek = await _repo.ProgramLogWeek.GetCurrentProgramLogWeekByUserId(userId);
            _validator.ValidateProgramLogWeekExists(programLogWeek);

            var programLogWeekDTO = _mapper.Map<ProgramLogWeekDTO>(programLogWeek);
            return programLogWeekDTO;
        }

        #endregion

        #region ProgramLogDayServices

        public async Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date)
        {
            _validator.ValidateProgramLogDayId(programLogId);
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, date);
            _validator.ValidateProgramLogDayExists(programLogDay);

            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogTodayDay(userId);
            _validator.ValidateProgramLogDayExists(programLogDay);
            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekById(programLogDayDTO.ProgramLogWeekId);
            _validator.ValidateProgramLogDayWithinProgramLogWeek(programLogWeek.StartDate, programLogWeek.EndDate, programLogDayDTO.Date);

            var newProgramLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _repo.ProgramLogDay.CreateProgramLogDay(newProgramLogDay);
        }

        #endregion

        #region ProgramLogExerciseServices

        public async Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId)
        {
            var programLogExercises = await _repo.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
            var programLogExercisesDTO = _mapper.Map<IEnumerable<ProgramLogExerciseDTO>>(programLogExercises);
            return programLogExercisesDTO;
        }

        public void CreateProgramLogExercise(ProgramLogExerciseDTO programLogExercise)
        {
            var newProgramLogExercise = _mapper.Map<ProgramLogExercise>(programLogExercise);
            _repo.ProgramLogExercise.CreateProgramLogExercise(newProgramLogExercise);
        }

        public async Task UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO)
        {
            var programLogExercise = await _repo.ProgramLogExercise.GetProgramLogExercise(programLogExerciseDTO.ProgramLogExerciseId);
            _validator.ValidateProgramExerciseExists(programLogExercise);

            _mapper.Map(programLogExerciseDTO, programLogExercise);
            _repo.ProgramLogExercise.UpdateProgramLogExercise(programLogExercise);
        }

        public async Task DeleteProgramLogExercise(int programLogExerciseId)
        {
            _validator.ValidateProgramLogExerciseId(programLogExerciseId);
            var programLogExercise = await _repo.ProgramLogExercise.GetProgramLogExercise(programLogExerciseId);
            _validator.ValidateProgramExerciseExists(programLogExercise);

            _repo.ProgramLogExercise.DeleteProgramLogExercise(programLogExercise);
        }

        #endregion

        #region ProgramLogRepScheme

        public void CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var newProgramLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _repo.ProgramLogRepScheme.CreateProgramLogRepScheme(newProgramLogRepScheme);
        }

        public async Task UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme(programLogRepSchemeDTO.ProgramLogRepSchemeId);
            _validator.ValidateProgramRepSchemeExists(programLogRepScheme);

            _mapper.Map(programLogRepSchemeDTO, programLogRepScheme);
            _repo.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepScheme);
        }

        public async Task DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            _validator.ValidateProgramLogRepSchemeId(programLogRepSchemeId);

            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme(programLogRepSchemeId);
            _validator.ValidateProgramRepSchemeExists(programLogRepScheme);

            _repo.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepScheme);
        }

        #endregion
    }
}