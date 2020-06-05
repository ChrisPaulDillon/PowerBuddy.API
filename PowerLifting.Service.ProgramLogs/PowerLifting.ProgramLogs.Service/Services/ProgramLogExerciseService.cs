using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.ProgramLogs.Contracts.Services;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.ProgramLogs.Service.Validator;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.ProgramLogs.Service.Services
{
    public class ProgramLogExerciseService : IProgramLogExerciseService
    {
        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _repo;
        private readonly UserManager<User> _userManager;

        public ProgramLogExerciseService(IProgramLogWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId)
        {
            var programLogExercises = await _repo.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
            var programLogExercisesDTO = _mapper.Map<IEnumerable<ProgramLogExerciseDTO>>(programLogExercises);
            return programLogExercisesDTO;
        }

        public async Task CreateProgramLogExercise(string userId, ProgramLogExerciseDTO programLogExercise)
        {
            var newProgramLogExercise = _mapper.Map<ProgramLogExercise>(programLogExercise);
            _repo.ProgramLogExercise.CreateProgramLogExercise(newProgramLogExercise);
            await CreateProgramLogExerciseAudit(userId, programLogExercise.ExerciseId);
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

        public async Task CreateProgramLogExerciseAudit(string userId, int exerciseId)
        {
            var audit = await _repo.ProgramLogExerciseAudit.GetProgramLogExerciseAudit(userId, exerciseId);
            if (audit == null)
            {
                var createAudit = new ProgramLogExerciseAudit()
                {
                    UserId = userId,
                    ExerciseId = exerciseId,
                    //exercisetypeid
                    SelectedCount = 1
                };
                _repo.ProgramLogExerciseAudit.CreateProgramLogExerciseAudit(createAudit);
            }
            else
            {
                audit.SelectedCount++;
                _repo.ProgramLogExerciseAudit.UpdateProgramLogExerciseAudit(audit);
            }
        }

        public Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
