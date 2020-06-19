using Microsoft.EntityFrameworkCore;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseMuscleGroupRepository : IExerciseMuscleGroupRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseMuscleGroupRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups()
        {
            return await _context.Set<ExerciseMuscleGroup>().AsNoTracking()
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            return await _context.Set<ExerciseMuscleGroup>()
                .Where(c => c.ExerciseMuscleGroupId == exerciseTypeId)
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<ExerciseMuscleGroup> CreateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroupDTO);
            _context.Add(exerciseMuscleGroup);

            await _context.SaveChangesAsync();
            return exerciseMuscleGroup;
        }

        public async Task<bool> UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroupDTO);
            _context.Update(exerciseMuscleGroup);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var exerciseMuscleGroup = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroupDTO);
            _context.Remove(exerciseMuscleGroup);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
