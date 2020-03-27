using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Powerlifting.Services.ProgramLogs.DTO;
using PowerLifting.Repositorys.RepositoryWrappers;
using PowerLifting.Services.ProgramLogs;

namespace Powerlifting.Services.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ProgramLogService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(int userId)
        {
            var logs = await _repo.ProgramLog.GetAllProgramLogsByUserId(userId);
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogById(int id)
        {
            var log = await _repo.ProgramLog.GetProgramLogById(id);
            var logDTO = _mapper.Map<ProgramLogDTO>(log);
            return logDTO;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetActiveProgramLogsByUserId(int userId)
        {
            var logs = await _repo.ProgramLog.GetActiveProgramLogsByUserId(userId);
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
        }

        public async void UpdateProgramLog(ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);
            if (programLog == null)
            {
                //throw new UserNotFoundException();
                //TODO
            }
            _mapper.Map(programLogDTO, programLog);
            _repo.ProgramLog.UpdateProgramLog(programLog);
        }
   
        public async void DeleteProgramLog(ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.ProgramLog.GetProgramLogById(programLogDTO.ProgramLogId);
            if (programLog == null)
            {
                //throw new UserNotFoundException();
            }
            _repo.ProgramLog.DeleteProgramLog(programLog);
        }

    }
}
