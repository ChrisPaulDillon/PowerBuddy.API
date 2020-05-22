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
using PowerLifting.Service.Users.Exceptions;
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

            if (userProgramLogs == null) throw new ProgramLogNotFoundException();

            var userProgramLogsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(userProgramLogs);
            return userProgramLogsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogByUserId(string userId)
        {
            var userProgramLog = await _repo.ProgramLog.GetProgramLogByUserId(userId);
            if (userProgramLog == null) throw new ProgramLogNotFoundException();

            var userProgramLogDTO = _mapper.Map<ProgramLogDTO>(userProgramLog);
            return userProgramLogDTO;
        }

        public async Task CreateProgramLog(ProgramLogDTO programLog)
        {
            var newProgramLog = _mapper.Map<ProgramLog>(programLog);
            _repo.ProgramLog.CreateProgramLog(newProgramLog);
        }

        private bool DoesProgramLogAlreadyExist(string userId)
        {
            return _repo.ProgramLog.DoesProgramLogAfterTodayExist(userId);
        }

        public ProgramLogDTO CreateProgramLogFromTemplate(int templateProgramId, DaySelected daySelected)
        {
            const string userId = "b6b44a7c-30f4-4c3f-bd0e-955e3e12e571";
            var validator = new ProgramLogValidator();

            if (DoesProgramLogAlreadyExist(userId)) throw new ProgramLogAlreadyActiveException(); //doesnt work lul

            var tp = _repo.TemplateProgram.GetTemplateProgramById(templateProgramId);
          
            if (tp == null) throw new TemplateProgramNotFoundException();

            var tec = _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(templateProgramId);

            daySelected = CountDaysSelected(daySelected);
            validator.ValidateProgramLogDaysMatchTemplateDaysCount(daySelected.Counter, tp.MaxLiftDaysPerWeek);

            var userLiftingStats = _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, 1);
            validator.ValiateUserHasLiftingStatSetForTemplateExercises(userLiftingStats);

            var checkLiftingStats = userLiftingStats.ToList().Where(item1 => tec.Any(item2 => item1.ExerciseId == item2));

            if (tec.Count() != checkLiftingStats.Count()) throw new TemplateExercise1RMNotSetForUserException();

            var newProgramLog = CreateProgramLog(tp, daySelected, userLiftingStats.ToList(), userId);
            var programLog = _mapper.Map<ProgramLog>(newProgramLog);
            _repo.ProgramLog.CreateProgramLog(programLog);
            return newProgramLog;
        }

        private static DaySelected CountDaysSelected(DaySelected ds)
        {
            ds.ProgramOrder = new Dictionary<int, string>();

            var startingDay = ds.StartDate.DayOfWeek;
            var startingNo = (int) ds.StartDate.DayOfWeek;

            var counter = 1;
            ds.ProgramOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                if(day == DayOfWeek.Monday)
                {
                    if (ds.Monday) ds.ProgramOrder.Add(++counter, day.ToString());
                }
                else if(day == DayOfWeek.Tuesday)
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

            ds.Counter = counter;
            return ds;
        }

        private ProgramLogDTO CreateProgramLog(TemplateProgram tp, DaySelected ds, List<LiftingStat> liftingStats, string userId)
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
                ProgramLogWeeks = GenerateProgramWeekDates(ds, tp, userId, liftingStats)
            };

            //log.ProgramLogWeeks = GenerateProgramExercises(tp, (List<ProgramLogWeekDTO>)log.ProgramLogWeeks, liftingStats);
            return log;
        }

        private List<ProgramLogWeekDTO> GenerateProgramWeekDates(DaySelected ds, TemplateProgram tp, string userId, List<LiftingStat> liftingStats)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            foreach(var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeekWithDays = CreateProgramLogWeek(templateWeek, ds, userId, liftingStats);
                listOfProgramWeeks.Add(programLogWeekWithDays);
                ds.StartDate = ds.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        private static ProgramLogWeekDTO CreateProgramLogWeek(TemplateWeek templateWeek, DaySelected ds, string userId, List<LiftingStat> liftingStats)
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
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Tuesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Wednesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Thursday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Friday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Saturday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Sunday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogDay.DayNo = templateDay.DayNo;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
            }
            return programLogWeek;
        }

        private static ProgramLogDayDTO GenerateProgramLogDay(DayOfWeek day, TemplateDay templateDay, DateTime startDate, List<LiftingStat> liftingStats)
        {
            var daysUntilSpecificDay = ((int)day - (int)startDate.DayOfWeek + 7) % 7;
            var nextMon = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDayDTO()
            {
                Date = nextMon,
                DayOfWeek = day.ToString(),
                DayNo = templateDay.DayNo,
                ProgramLogExercises = CreateProgramLogExercises(templateDay, liftingStats)
            };
            return programLogDay;
        }

        private static List<ProgramLogExerciseDTO> CreateProgramLogExercises(TemplateDay templateDay, List<LiftingStat> liftingStats)
        {
            var programLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = new ProgramLogExerciseDTO()
                {
                    NoOfSets = temExercise.NoOfSets,
                    ExerciseId = temExercise.ExerciseId,
                    HasBackOffSets = temExercise.HasBackOffSets,
                    BackOffSetFormat = temExercise.BackOffSetFormat,
                    RepSchemeFormat = temExercise.RepSchemeFormat,
                    RepSchemeType = temExercise.RepSchemeType,
                    ProgramLogRepSchemes = new List<ProgramLogRepSchemeDTO>()
                };
                var user1RMOnLift = liftingStats.SingleOrDefault(x => x.ExerciseId == temExercise.ExerciseId);

                foreach (var temReps in temExercise.TemplateRepSchemes)
                {
                    var programRepSchema = GenerateProgramLogRepScheme("PERCENTAGE", user1RMOnLift.Weight, temReps);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                }
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        private static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string weightProgressionType, double user1RM, TemplateRepScheme templateRepScheme)
        {
            var weightToLift = 0.0;

            if (Enum.TryParse(weightProgressionType, out WeightProgressionTypeEnum weightProgressionTypeEnum))
            {
                switch (weightProgressionTypeEnum)
                {
                    case WeightProgressionTypeEnum.PERCENTAGE:
                        var percent = templateRepScheme.Percentage / 100;
                        weightToLift = Convert.ToDouble(user1RM * percent);
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
                IsBackOffSet = templateRepScheme.IsBackOffSet
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
            _repo.ProgramLog.UpdateProgramLog(programLog);
            return programLogDTO;
        }

        public async Task DeleteProgramLog(string userId, int programLogId)
        {
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogId(programLogId);

            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogId);

            if (programLog == null) throw new ProgramLogNotFoundException();
            if (programLog.UserId != userId)
            {
                throw new UnauthorisedUserException("UserId does match the user associated with this program log!");
            }

            _repo.ProgramLog.DeleteProgramLog(programLog);
        }

        #endregion

        #region ProgramLogWeekServices

        public async Task<ProgramLogWeekDTO> GetProgramLogWeekByProgramLogId(int programLogId, DateTime date)
        {
            //_validator.ValidateProgramLogWeekId(programLogWeekId);
            var programLogWeek = await _repo.ProgramLogWeek.GetCurrentProgramLogWeekByUserId("test lmfao");
            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            var programLogWeekDTO = _mapper.Map<ProgramLogWeekDTO>(programLogWeek);
            return programLogWeekDTO;
        }

        #endregion

        #region ProgramLogDayServices

        public async Task<ProgramLogDayDTO> GetProgramLogDayByUserId(string userId, int programLogId, DateTime date)
        {
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogDayId(programLogId);

            var programLogDay = await _repo.ProgramLogDay.GetProgramLogDay(userId, programLogId, date);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId)
        {
            var programLogDay = await _repo.ProgramLogDay.GetProgramLogTodayDay(userId);
            if (programLogDay == null) throw new ProgramLogDayNotFoundException();

            var programLogDayDTO = _mapper.Map<ProgramLogDayDTO>(programLogDay);
            return programLogDayDTO;
        }

        public async Task CreateProgramLogDay(ProgramLogDayDTO programLogDayDTO)
        {
            var programLogWeek = await _repo.ProgramLogWeek.GetProgramLogWeekById(programLogDayDTO.ProgramLogWeekId);
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogDayWithinProgramLogWeek(programLogWeek.StartDate, programLogWeek.EndDate, programLogDayDTO.Date);

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
            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();
            
            _mapper.Map(programLogExerciseDTO, programLogExercise);
            _repo.ProgramLogExercise.UpdateProgramLogExercise(programLogExercise);
        }

        public async Task DeleteProgramLogExercise(int programLogExerciseId)
        {
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogExerciseId(programLogExerciseId);

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
            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme(programLogRepSchemeDTO.ProgramLogRepSchemeId);
            if (programLogRepScheme == null) throw new ProgramLogRepSchemeNotFoundException();

            _mapper.Map(programLogRepSchemeDTO, programLogRepScheme);
            _repo.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepScheme);
        }

        public async Task DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            var validator = new ProgramLogValidator();
            validator.ValidateProgramLogRepSchemeId(programLogRepSchemeId);

            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepScheme(programLogRepSchemeId);
            if (programLogRepScheme == null) throw new ProgramLogRepSchemeNotFoundException();

            _repo.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepScheme);
        }

        #endregion
    }
}