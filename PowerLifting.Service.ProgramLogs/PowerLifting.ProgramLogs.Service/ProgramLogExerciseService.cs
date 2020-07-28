using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.ProgramLogs.Service.Wrapper;

namespace PowerLifting.ProgramLogs.Service
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
            var programLogExercisesDTO = await _repo.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
            return programLogExercisesDTO;
        }

        public async Task<ProgramLogExercise> GetProgramLogExerciseById(int programLogExerciseId)
        {
            return await _repo.ProgramLogExercise.GetProgramLogExerciseById(programLogExerciseId);
        }

        public async Task<ProgramLogExercise> CreateProgramLogExercise(string userId, Exercise exercise, CProgramLogExerciseDTO programLogExercise)
        {
            var doesExerciseExist = await _repo.ProgramLogExercise.DoesExerciseExistForDay(programLogExercise.ProgramLogDayId, programLogExercise.ExerciseId);
            if (doesExerciseExist == 0)
            {
                if (programLogExercise.RepSchemeType.Contains("Fixed"))
                {
                    var noOfSets = programLogExercise.NoOfSets;
                    var repSchemeCollection = new List<CProgramLogRepSchemeDTO>();

                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        var repScheme = new CProgramLogRepSchemeDTO()
                        {
                            SetNo = i,
                            NoOfReps = (int)programLogExercise.Reps,
                            WeightLifted = (double)programLogExercise.Weight,
                        };
                        repSchemeCollection.Add(repScheme);
                    }
                    programLogExercise.ProgramLogRepSchemes = repSchemeCollection;
                }

                var createdExercise = await _repo.ProgramLogExercise.CreateProgramLogExercise(programLogExercise);
                createdExercise.Exercise = exercise;
                return createdExercise;
                //await CreateProgramLogExerciseAudit(userId, programLogExercise.ExerciseId);
            }
            else
            {
                var exerciseEntity = await _repo.ProgramLogExercise.GetProgramLogExerciseById(doesExerciseExist);
                if (programLogExercise.RepSchemeType.Contains("Fixed"))
                {
                    var noOfSets = programLogExercise.NoOfSets;
                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        var repScheme = new ProgramLogRepScheme()
                        {
                            SetNo = i,
                            NoOfReps = (int)programLogExercise.Reps,
                            WeightLifted = (decimal)programLogExercise.Weight,
                        };
                        exerciseEntity.ProgramLogRepSchemes.Add(repScheme);
                    }
                }
                exerciseEntity.NoOfSets += programLogExercise.NoOfSets;
                await _repo.ProgramLogExercise.SaveChangesAsync();
                return exerciseEntity;
            }
        }

        public async Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO)
        {
            var doesExist = await _repo.ProgramLogExercise.DoesExerciseExist(programLogExerciseDTO.ProgramLogExerciseId);
            if (!doesExist) throw new ProgramLogExerciseNotFoundException();

            return await _repo.ProgramLogExercise.UpdateProgramLogExercise(programLogExerciseDTO);
        }

        public async Task<bool> DeleteProgramLogExercise(int programLogExerciseId)
        {
            //var validator = new ProgramLogValidator();
            //validator.ValidateProgramLogExerciseId(programLogExerciseId);

            var doesExist = await _repo.ProgramLogExercise.DoesExerciseExist(programLogExerciseId);
            if (!doesExist) throw new ProgramLogExerciseNotFoundException();

            return await _repo.ProgramLogExercise.DeleteProgramLogExercise(new ProgramLogExerciseDTO() { ProgramLogExerciseId = programLogExerciseId });
        }

        public async Task<int> CreateProgramLogExerciseAudit(string userId, int exerciseId)
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
                return await _repo.ProgramLogExerciseAudit.CreateProgramLogExerciseAudit(createAudit);
            }
            return 0;
        }

        public Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MarkProgramLogExerciseComplete(int programLogExerciseId, bool isCompleted)
        {
            var programLogExerciseDTO = await _repo.ProgramLogExercise.GetProgramLogExerciseById(programLogExerciseId);
            var programLogExercise = _mapper.Map<ProgramLogExercise>(programLogExerciseDTO);
            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();
            programLogExercise.Completed = isCompleted;
            return await _repo.ProgramLogExercise.MarkProgramLogExerciseComplete(programLogExercise);
        }
    }
}
