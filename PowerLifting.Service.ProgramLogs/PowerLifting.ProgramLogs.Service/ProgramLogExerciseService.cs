using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Persistence;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogExerciseService : IProgramLogExerciseService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogExerciseService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId, string userId)
        {
            var programLogExercisesDTO = await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogDayId == programLogDayId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return programLogExercisesDTO;
        }

        public async Task<ProgramLogExercise> GetProgramLogExerciseById(int programLogExerciseId)
        {
            return await _context.Set<ProgramLogExercise>()
                .Where(x => x.ProgramLogExerciseId == programLogExerciseId)
                .Include(x => x.ProgramLogRepSchemes)
                .Include(x => x.Exercise)
                .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogExerciseDTO> CreateProgramLogExercise(CProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            var doesExerciseExist = await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == programLogExerciseDTO.ProgramLogDayId && x.ExerciseId == programLogExerciseDTO.ExerciseId);

            if (doesExerciseExist)
            {
                if (programLogExerciseDTO.RepSchemeType.Contains("Fixed"))
                {
                    var noOfSets = programLogExerciseDTO.NoOfSets;
                    var repSchemeCollection = new List<CProgramLogRepSchemeDTO>();

                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        var repScheme = new CProgramLogRepSchemeDTO()
                        {
                            SetNo = i,
                            NoOfReps = (int)programLogExerciseDTO.Reps,
                            WeightLifted = (double)programLogExerciseDTO.Weight,
                        };
                        repSchemeCollection.Add(repScheme);
                    }
                    programLogExerciseDTO.ProgramLogRepSchemes = repSchemeCollection;
                }

                var programLogExerciseEntity = _mapper.Map<ProgramLogExercise>(programLogExerciseDTO);
                _context.Add(programLogExerciseEntity);
                await _context.SaveChangesAsync();

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
                //await CreateProgramLogExerciseAudit(userId, programLogExercise.ExerciseId);
            }
            else //exercise already exists for the given day, add to it
            {
                var programLogExerciseEntity = await _context.Set<ProgramLogExercise>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.ProgramLogDayId == programLogExerciseDTO.ProgramLogDayId &&
                        x.ExerciseId == programLogExerciseDTO.ExerciseId);

                if (programLogExerciseDTO.RepSchemeType.Contains("Fixed"))
                {
                    var noOfSets = programLogExerciseDTO.NoOfSets;
                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        var repScheme = new ProgramLogRepScheme()
                        {
                            SetNo = i,
                            NoOfReps = (int) programLogExerciseDTO.Reps,
                            WeightLifted = (decimal) programLogExerciseDTO.Weight,
                        };
                        programLogExerciseEntity.ProgramLogRepSchemes.Add(repScheme);
                    }
                }

                programLogExerciseEntity.NoOfSets += programLogExerciseDTO.NoOfSets;
                await _context.SaveChangesAsync();

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
            }
        }

        public async Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO, string userId)
        {
            var programLogDayId = await _context.ProgramLogExercise.AsNoTracking().Where(x => x.ProgramLogExerciseId == programLogExerciseDTO.ProgramLogExerciseId).Select(x => x.ProgramLogDayId).FirstOrDefaultAsync();
            if (programLogDayId == 0) throw new ProgramLogExerciseNotFoundException();

            var doesLogDayExist = await _context.ProgramLogDay.AsNoTracking().AnyAsync(x => x.ProgramLogDayId == programLogDayId && x.UserId == userId);
            if (!doesLogDayExist) throw new UnauthorisedUserException();

            var programLogExercise = _mapper.Map<ProgramLogExercise>(programLogExerciseDTO);
            _context.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLogExercise(int programLogExerciseId, string userId)
        {
            var programLogDayId = await _context.ProgramLogExercise.AsNoTracking().Where(x => x.ProgramLogExerciseId == programLogExerciseId).Select(x => x.ProgramLogDayId).FirstOrDefaultAsync();
            if (programLogDayId == 0) throw new ProgramLogExerciseNotFoundException();

            var doesLogDayExist = await _context.ProgramLogDay.AsNoTracking().AnyAsync(x => x.ProgramLogDayId == programLogDayId && x.UserId == userId);
            if(!doesLogDayExist) throw new UnauthorisedUserException();

            _context.Remove(new ProgramLogExercise() { ProgramLogExerciseId = programLogExerciseId});

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<int> CreateProgramLogExerciseAudit(string userId, int exerciseId)
        {
            var audit = await _context.Set<ProgramLogExerciseAudit>()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .FirstOrDefaultAsync();

            if (audit == null)
            {
                var createAudit = new ProgramLogExerciseAudit()
                {
                    UserId = userId,
                    ExerciseId = exerciseId,
                    //exercisetypeid
                    SelectedCount = 1
                }; 
                _context.Add(audit);

                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId)
        {
            return await _context.Set<ProgramLogExerciseAudit>().AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.SelectedCount).Take(3)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> MarkProgramLogExerciseComplete(int programLogExerciseId, bool isCompleted)
        {
            var programLogExercise = await _context.ProgramLogExercise.FirstOrDefaultAsync(x => x.ProgramLogExerciseId == programLogExerciseId);
            if (programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            programLogExercise.Completed = isCompleted;
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}
