using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Powerlifting.Services.ProgramLogs.DTO;
using PowerLifting.Services.ProgramLogs;

namespace Powerlifting.Services.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private IMapper _mapper;
        private IProgramLogRepository _repo;

        public ProgramLogService(IProgramLogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetAllProgramLogsByUserId(int userId)
        {
            var logs = await _repo.GetAllProgramLogsByUserId(userId);
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
        }

        public async Task<ProgramLogDTO> GetProgramLogById(int id)
        {
            var log = await _repo.GetProgramLogById(id);
            var logDTO = _mapper.Map<ProgramLogDTO>(log);
            return logDTO;
        }

        public async Task<IEnumerable<ProgramLogDTO>> GetActiveProgramLogsByUserId(int userId)
        {
            var logs = await _repo.GetActiveProgramLogsByUserId(userId);
            var logsDTO = _mapper.Map<IEnumerable<ProgramLogDTO>>(logs);
            return logsDTO;
        }


        public async void UpdateProgramLog(ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.GetProgramLogById(programLogDTO.ProgramLogId);
            if (programLog == null)
            {
                //throw new UserNotFoundException();
                //TODO
            }
            _mapper.Map(programLogDTO, programLog);
            _repo.UpdateProgramLog(programLog);
        }
   
        public async void DeleteProgramLog(ProgramLogDTO programLogDTO)
        {
            var programLog = await _repo.GetProgramLogById(programLogDTO.ProgramLogId);
            if (programLog == null)
            {
                //throw new UserNotFoundException();
            }
            _repo.DeleteProgramLog(programLog);
        }

    }
}
