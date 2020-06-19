using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            return await _context.Set<Exercise>().AsNoTracking()
                .Include(m => m.ExerciseMuscleGroups)
                .Include(t => t.ExerciseType)
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            return await _context.Set<Exercise>().AsNoTracking()
                .Where(c => c.ExerciseId == id)
                .Include(m => m.ExerciseMuscleGroups)
                .Include(t => t.ExerciseType).AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DoesExerciseExist(int exerciseId)
        {
            return await _context.Set<Exercise>()
                .Where(x => x.ExerciseId == exerciseId)
                .AsNoTracking()
                .AnyAsync();
        }

        public async Task<bool> DoesExerciseNameExist(string exerciseName)
        {
            return await _context.Set<Exercise>()
                .Where(x => x.ExerciseName == exerciseName)
                .AsNoTracking()
                .AnyAsync();
        }

        public async Task<bool> UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Update(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
