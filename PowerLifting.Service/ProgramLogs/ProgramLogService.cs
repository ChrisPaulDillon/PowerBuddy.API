using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            if(log != null)
            {
                throw new ProgramLogAlreadyExistsException();
            }
            var newProgramLog = _mapper.Map<ProgramLog>(programLog);
            _repo.ProgramLog.CreateProgramLog(newProgramLog);
            //return programLog;
        }

        public async Task CreateProgramLogFromTemplate(int programTemplateId, DaySelected daySelected)
        {
            var templateProgram = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);

            if (templateProgram == null) throw new TemplateProgramDoesNotExistException();

            var dayCounter = CountDaysSelected(daySelected);
            if (templateProgram.MaxLiftDaysPerWeek != dayCounter)
            {
                throw new ProgramDaysDoesNotMatchTemplateDaysException();
            }

            var newProgramLog = MapTemplateToProgramLog(templateProgram, daySelected);
            _repo.ProgramLog.CreateProgramLog(newProgramLog);
        }

        private int CountDaysSelected(DaySelected ds)
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

        private ProgramLog MapTemplateToProgramLog(TemplateProgram tp, DaySelected ds)
        { 
            var log = new ProgramLog()
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
                 NoOfWeeks = tp.NoOfWeeks
            };

            log.ProgramLogWeeks = GenerateProgramWeekDates(ds, tp.NoOfWeeks);
            return log;
        }

        private List<ProgramLogWeek> GenerateProgramWeekDates(DaySelected ds, int noOfWeeks)
        {
            var listOfProgramWeeks = new List<ProgramLogWeek>();
            
            for (int i = 0; i < noOfWeeks; i++)
            {
                var programLogWeek = new ProgramLogWeek()
                {
                    StartDate = ds.StartDate,
                    EndDate = ds.StartDate.AddDays(7),
                    WeekNumber = i
                };
                listOfProgramWeeks.Add(GenerateProgramLogDaysForWeek(programLogWeek, ds));
                ds.StartDate = ds.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        private ProgramLogWeek GenerateProgramLogDaysForWeek(ProgramLogWeek programLogWeek, DaySelected ds)
        {
            
                var listOfProgramDays = new List<ProgramLogDay>();
                var startDate = programLogWeek.StartDate;
                if(ds.Monday)
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

        private ProgramLogDay GenerateProgramLogDay(string dayOfWeek, DateTime startDate)
        {
            int daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
            DateTime nextMon = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDay()
            {
                Date = nextMon,
                DayOfWeek = dayOfWeek,
                //Add teh stoof
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
            var programLogWeek =  await _repo.ProgramLogWeek.GetCurrentProgramLogWeekByUserId(userId, programLogId);
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
            var programLogWeek = await _repo.ProgramLog.GetProgramLogById(programLogDayDTO.ProgramLogId);
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
    }
}