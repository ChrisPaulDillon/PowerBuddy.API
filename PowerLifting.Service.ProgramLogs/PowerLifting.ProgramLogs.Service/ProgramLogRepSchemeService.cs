using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.ProgramLogs.Service.Wrapper;

namespace PowerLifting.ProgramLogs.Service
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


        public async Task<bool> CreateProgramLogExerciseCollection(IEnumerable<ProgramLogRepSchemeDTO> repSchemeCollection)
        {
            var repList = repSchemeCollection.ToList();
            var programLogExercise = await _repo.ProgramLogExercise.GetProgramLogExerciseById(repList[0].ProgramLogExerciseId);
            programLogExercise.NoOfSets += repList.Count();

            foreach (var item in repList)
            {
                await _repo.ProgramLogRepScheme.CreateProgramLogRepScheme(item);
            }

            return true;
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
