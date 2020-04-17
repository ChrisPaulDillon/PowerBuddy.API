using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public ProgramLogService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProgramLogDTO> GetTodaysProgramLogByUserId(string userId)
        {
            //var programLog = await _repo.ProgramLog.GetTodaysProgramLogByUserId(userId);
            ProgramLogDTO programLog = null;
            if (programLog == null)
                throw new ProgramLogNotFoundException("The program log for this specific day cannot be found!");
            var logsDTO = _mapper.Map<ProgramLogDTO>(programLog);
            return logsDTO;
        }

        public async Task<ProgramLogDTO> GetWeeklyProgramLogByUserId(string userId)
        {
            //var programLog = await _repo.ProgramLog.GetWeeklyProgramLogByUserId(userId);
            ProgramLogDTO programLog = null;
            if (programLog == null)
                throw new ProgramLogNotFoundException("The program log for this specific week cannot be found!");
            var logDTO = _mapper.Map<ProgramLogDTO>(programLog);
            return logDTO;
        }

        public async Task<ProgramLogDTO> GetActiveProgramLogByUserId(string userId)
        {
            var logs = await _repo.ProgramLog.GetActiveProgramLogByUserId(userId);
            if (logs == null) throw new ProgramLogNotFoundException("The program log selected cannot be found!");
            var logsDTO = _mapper.Map<ProgramLogDTO>(logs);
            return logsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogByProgramLogId(int programLogId)
        {
            //var logs = await _repo.ProgramLog.GetProgramLogByProgramLogId(programLogId);
            ProgramLogDTO programLog = null;
            if (programLog == null) throw new ProgramLogNotFoundException("This specific program log cannot be found!");
            var logsDTO = _mapper.Map<ProgramLogDTO>(programLog);
            return logsDTO;
        }

        public async void UpdateProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            //var programLog = await _repo.ProgramLog.GetProgramLogByProgramLogId(programLogDTO.ProgramLogId);
            ProgramLog programLog = null;
            if (programLog.UserId != userId)
                throw new UserDoesNotMatchProgramLogException(
                    "UserId does match the user associated with this program log!");
            if (programLog == null) throw new ProgramLogNotFoundException("ProgramLog was not found!");
            _mapper.Map(programLogDTO, programLog);
            _repo.ProgramLog.UpdateProgramLog(programLog);
        }

        public async void DeleteProgramLog(string userId, ProgramLogDTO programLogDTO)
        {
            //var programLog = await _repo.ProgramLog.GetProgramLogByProgramLogId(programLogDTO.ProgramLogId);
            ProgramLog programLog = null;
            if (programLog.UserId != userId)
                throw new UserDoesNotMatchProgramLogException(
                    "UserId does match the user associated with this program log!");
            if (programLog == null) throw new ProgramLogNotFoundException("ProgramLog was not found!");
            _repo.ProgramLog.DeleteProgramLog(programLog);
        }
    }
}