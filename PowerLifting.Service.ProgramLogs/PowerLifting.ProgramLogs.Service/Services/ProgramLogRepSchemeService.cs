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

        public void CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var newProgramLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _repo.ProgramLogRepScheme.CreateProgramLogRepScheme(newProgramLogRepScheme);
        }

        public async Task UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var doesExist = await _repo.ProgramLogRepScheme.DoesRepSchemeExist(programLogRepSchemeDTO.ProgramLogRepSchemeId);
            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            var updatedRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _repo.ProgramLogRepScheme.UpdateProgramLogRepScheme(updatedRepScheme);
        }

        public async Task DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            var doesExist = await _repo.ProgramLogRepScheme.DoesRepSchemeExist(programLogRepSchemeId);
            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            _repo.ProgramLogRepScheme.DeleteProgramLogRepScheme(new ProgramLogRepScheme() { ProgramLogRepSchemeId = programLogRepSchemeId });
        }
    }
}
