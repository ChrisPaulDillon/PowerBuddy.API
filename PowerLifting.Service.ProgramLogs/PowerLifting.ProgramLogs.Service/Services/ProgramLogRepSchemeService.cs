using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.ProgramLogs.Service.Services
{
    public class ProgramLogRepSchemeService : IProgramLogRepSchemeService
    {
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;
        private readonly UserManager<User> _userManager;

        public ProgramLogRepSchemeService(IProgramLogWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ProgramLogRepScheme> CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            return await _repo.ProgramLogRepScheme.CreateProgramLogRepScheme(programLogRepSchemeDTO);
        }

        public async Task<bool> UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var doesExist = await _repo.ProgramLogRepScheme.DoesRepSchemeExist(programLogRepSchemeDTO.ProgramLogRepSchemeId);
            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            return await _repo.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepSchemeDTO);
        }

        public async Task<bool> DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            var doesExist = await _repo.ProgramLogRepScheme.DoesRepSchemeExist(programLogRepSchemeId);
            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            return await _repo.ProgramLogRepScheme.DeleteProgramLogRepScheme(new ProgramLogRepSchemeDTO() { ProgramLogRepSchemeId = programLogRepSchemeId });
        }

        public async Task<bool> MarkProgramLogRepSchemeComplete(int programLogRepSchemeId, bool isCompleted)
        {
            var programLogRepScheme = await _repo.ProgramLogRepScheme.GetProgramLogRepSchemeById(programLogRepSchemeId);
            if (programLogRepScheme == null) throw new ProgramLogRepSchemeNotFoundException();
            programLogRepScheme.Completed = isCompleted;
            return await _repo.ProgramLogRepScheme.MarkProgramLogRepSchemeComplete(programLogRepScheme);
        }
    }
}
