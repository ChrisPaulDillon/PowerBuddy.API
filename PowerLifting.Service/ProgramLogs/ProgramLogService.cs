﻿using System;
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
using PowerLifting.Service.ServiceWrappers;
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

        public ProgramLogService(IRepositoryWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        #region ProgramLogServices

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(string userId)
        {
            var userProgramLogs = await _repo.ProgramLog.GetAllProgramLogsByUserId(userId);
            var userProgramLogsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(userProgramLogs);
            return userProgramLogsDTO;
        }

        public async Task CreateProgramLog(ProgramLogDTO programLog)
        {
            var log = await _repo.ProgramLog.GetProgramLogById(programLog.ProgramLogId);
            if (log != null)
            {
                throw new ProgramLogAlreadyExistsException();
            }
            var newProgramLog = _mapper.Map<ProgramLog>(programLog);
            _repo.ProgramLog.CreateProgramLog(newProgramLog);
            //return programLog;
        }

        private bool DoesProgramLogAlreadyExist(string userId)
        {
            return _repo.ProgramLog.DoesProgramLogAfterTodayExist(userId);
        }

        public async Task CreateProgramLogFromTemplate(int templateProgramId, DaySelected daySelected)
        {
            const string userId = "20ea3a83-72f0-46ea-9637-d4168d1e1d85";
            var programLogAlreadyActivate = DoesProgramLogAlreadyExist(userId);

            if (programLogAlreadyActivate) throw new ProgramLogAlreadyActiveException();

            var tp = await _repo.TemplateProgram.GetTemplateProgramById(templateProgramId);

            if (tp == null) throw new TemplateProgramDoesNotExistException();

            var tec = await _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(templateProgramId);

            var dayCounter = CountDaysSelected(daySelected);
            if (tp.MaxLiftDaysPerWeek != dayCounter)
            {
                throw new ProgramDaysDoesNotMatchTemplateDaysException();
            }

            var userLiftingStats = await _repo.LiftingStat
                .GetLiftingStatsByUserIdAndRepRange(userId, 1);

            var liftingStats = userLiftingStats.ToList();
            if (userLiftingStats == null || !liftingStats.Any()) throw new TemplateExercise1RMNotSetForUserException();

            var checkLiftingStats = liftingStats.Where(item1 => tec.Any(item2 => item1.ExerciseId == item2));

            var userLiftingStatsCount = liftingStats.Count();
            var programLiftingStats = checkLiftingStats.Count();

            if (userLiftingStatsCount != programLiftingStats) throw new TemplateExercise1RMNotSetForUserException();

            var newProgramLog = CreateProgramLog(tp, daySelected, liftingStats);
            var programLog = _mapper.Map<ProgramLog>(newProgramLog);
            _repo.ProgramLog.CreateProgramLog(programLog);
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

        private ProgramLogDTO CreateProgramLog(TemplateProgram tp, DaySelected ds, IEnumerable<LiftingStat> liftingStats)
        {
            var log = new ProgramLogDTO
            {
                TemplateProgramId = tp.TemplateProgramId,
                Monday = ds.Monday,
                Tuesday = ds.Tuesday,
                Wednesday = ds.Wednesday,
                Thursday = ds.Thursday,
                Friday = ds.Friday,
                Saturday = ds.Saturday,
                Sunday = ds.Sunday,
                StartDate = ds.StartDate,
                NoOfWeeks = tp.NoOfWeeks,
                ProgramLogWeeks = GenerateProgramWeekDates(ds, tp.NoOfWeeks)
            };

            log.ProgramLogWeeks = GenerateProgramExercises(tp,
                                                           (List<ProgramLogWeekDTO>)log.ProgramLogWeeks,
                                                           (List<LiftingStat>)liftingStats);
            return log;
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
                                    var programRepSchema = GenerateProgramLogRepScheme(templateProgram.TemplateType, user1RMOnLift.Weight, temReps);
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

        private static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string templateType, double user1RM, TemplateRepScheme repSchema)
        {
            var weightToLift = 0.0;
            if (templateType == Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE))
            {
                var percent = repSchema.Percentage / 100;
                weightToLift = Convert.ToDouble(user1RM * percent);
            }
            if (templateType == Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL))
            {

            }

            return new ProgramLogRepSchemeDTO()
            {
                SetNo = repSchema.SetNo,
                NumOfReps = repSchema.NumOfReps,
                Percentage = repSchema.Percentage,
                WeightLifted = weightToLift
            };
        }

        private List<ProgramLogWeekDTO> GenerateProgramWeekDates(DaySelected ds, int noOfWeeks)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            for (var i = 1; i < noOfWeeks + 1; i++)
            {
                var programLogWeek = new ProgramLogWeekDTO()
                {
                    StartDate = ds.StartDate,
                    EndDate = ds.StartDate.AddDays(7),
                    WeekNumber = i
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
                var programLogDay = GenerateProgramLogDay("Monday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Tuesday)
            {
                var programLogDay = GenerateProgramLogDay("Tuesday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Wednesday)
            {
                var programLogDay = GenerateProgramLogDay("Wednesday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Thursday)
            {
                var programLogDay = GenerateProgramLogDay("Thursday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Friday)
            {
                var programLogDay = GenerateProgramLogDay("Friday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Saturday)
            {
                var programLogDay = GenerateProgramLogDay("Saturday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            if (ds.Sunday)
            {
                var programLogDay = GenerateProgramLogDay("Sunday", startDate);
                listOfProgramDays.Add(programLogDay);
            }
            programLogWeek.ProgramLogDays = listOfProgramDays;
            return programLogWeek;
        }

        private static ProgramLogDayDTO GenerateProgramLogDay(string dayOfWeek, DateTime startDate)
        {
            var daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
            var nextMon = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDayDTO()
            {
                Date = nextMon,
                DayOfWeek = dayOfWeek,
                ProgramLogExercises = new List<ProgramLogExerciseDTO>()
            };
            return programLogDay;
        }

        public async Task<ProgramLogDTO> UpdateProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);

            if (programLog.UserId != userId)
            {
                throw new UserDoesNotMatchProgramLogException("UserId does match the user associated with this program log!");
            }

            if (programLog == null) throw new ProgramLogNotFoundException("ProgramLog was not found!");

            _mapper.Map(programLogDTO, programLog);
            _repo.ProgramLog.UpdateProgramLog(programLog);
            return programLogDTO;
        }

        public async Task DeleteProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);

            if (programLog.UserId != userId)
            {
                throw new UserDoesNotMatchProgramLogException("UserId does match the user associated with this program log!");
            }

            if (programLog == null) throw new ProgramLogNotFoundException("ProgramLog was not found!");

            _repo.ProgramLog.DeleteProgramLog(programLog);
        }

        #endregion

        #region ProgramLogWeekServices

        public async Task<ProgramLogWeekDTO> GetCurrentProgramLogWeekByUserId(string userId, int programLogId)
        {
            var programLogWeek = await _repo.ProgramLogWeek.GetCurrentProgramLogWeekByUserId(userId, programLogId);
            var programLogWeekDTO = _mapper.Map<ProgramLogWeekDTO>(programLogWeek);
            return programLogWeekDTO;
        }

        #endregion

        #region ProgramLogDayServices

        public async Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, date);
            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId, int programLogId)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, DateTime.Now);
            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogWeek = await _repo.ProgramLog.GetProgramLogById(programLogDayDTO.ProgramLogDayId); //TODO FIX
            var isWithinWeekRange = programLogDayDTO.Date >= programLogWeek.StartDate && programLogDayDTO.Date < programLogWeek.EndDate;

            if (!isWithinWeekRange) throw new ProgramLogDayNotWithWeekRangeException();

            var newProgramLogDay = _mapper.Map<ProgramLogDay>(programLogDayDTO);
            _repo.ProgramLogDay.CreateProgramLogDay(newProgramLogDay);
        }

        #endregion

        #region ProgramLogExerciseServices

        public void CreateProgramLogExercise(ProgramLogExerciseDTO programLogExercise)
        {
            var newProgramLogExercise = _mapper.Map<ProgramLogExercise>(programLogExercise);
            _repo.ProgramLogExercise.CreateProgramLogExercise(newProgramLogExercise);
        }

        public async Task UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO)
        {
            var programLogExercise = await _repo.ProgramLogExercise.GetProgramLogExercise(programLogExerciseDTO.ProgramLogExerciseId);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            _mapper.Map(programLogExerciseDTO, programLogExercise);
            _repo.ProgramLogExercise.UpdateProgramLogExercise(programLogExercise);
        }

        public async void DeleteProgramLogExercise(int programLogExerciseId)
        {
            var programLogExercise = await _repo.ProgramLogExercise.GetProgramLogExercise(programLogExerciseId);

            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

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
            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme
                                                                    (programLogRepSchemeDTO.ProgramLogExerciseId);

            if (programLogRepScheme == null) throw new ProgramLogExerciseNotFoundException();

            _mapper.Map(programLogRepSchemeDTO, programLogRepScheme);
            _repo.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepScheme);
        }

        public async Task DeleteProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme(programLogRepSchemeDTO.ProgramLogRepSchemeId);

            if (programLogRepScheme == null) throw new ProgramLogExerciseNotFoundException();

            _repo.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepScheme);
        }

        #endregion
    }
}