using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.ServiceWrappers;
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

        public Task<ProgramLogDTO> GetAllProgramLogsByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async void UpdateProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);

            if (programLog.UserId != userId)
            {
                throw new UserDoesNotMatchProgramLogException("UserId does match the user associated with this program log!");
            }

            if (programLog == null) throw new ProgramLogNotFoundException("ProgramLog was not found!");

            _mapper.Map(programLogDTO, programLog);
            _repo.ProgramLog.UpdateProgramLog(programLog);
        }

        public async void DeleteProgramLog(string userId, ProgramLogDTO programLogDTO)
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

        public Task<ProgramLogWeekDTO> GetActiveProgramLogWeekByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProgramLogDayDTO> GetTodaysProgramLogDayByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateProgramLogExercise(ProgramLogExerciseDTO programLogExercise)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExercise)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProgramLogExercise(ProgramLogExerciseDTO programLogExercise)
        {
            throw new System.NotImplementedException();
        }
    }
}