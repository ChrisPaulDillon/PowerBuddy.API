using AutoMapper;
using PowerLifting.Data.DTOs.System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Persistence;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.Exercises.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllUnapprovedExercises()
        {
       
        }

        public async Task<Exercise> GetExerciseById(int exerciseId)
        {
            if (exerciseId <= 0) throw new ExerciseValidationException("ExerciseId must be greater than zero");

            var exercise = await _context.Set<Exercise>()
                .Where(x => x.ExerciseId == exerciseId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (exercise == null) throw new ExerciseNotFoundException();

            return exercise;
        }

        public async Task<ExerciseDTO> CreateExercise(CExerciseDTO cExerciseDTO)
        {
            var doesExist = await _context.Exercise
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == cExerciseDTO.ExerciseName);

            if (doesExist) throw new ExerciseAlreadyExistsException();

            var exercise = _mapper.Map<Exercise>(cExerciseDTO);
            _context.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async Task<bool> UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(x => x.ExerciseId == exerciseDTO.ExerciseId);

            if (exercise == null) throw new ExerciseNotFoundException();
             
            _mapper.Map(exerciseDTO, exercise);
            _context.Update(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteExercise(int exerciseId)
        {
            var exercise =  await _context.Exercise
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ExerciseId == exerciseId);
            
            if (exercise == null) throw new ExerciseNotFoundException();

            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

    }
}