using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseTypeRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes()
        {
            return await _context.Set<ExerciseType>()
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId)
        {
            return await _context.Set<ExerciseType>()
                .Where(c => c.ExerciseTypeId == exerciseTypeId)
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<ExerciseType> CreateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            _context.Update(exerciseType);

            await _context.SaveChangesAsync();
            return exerciseType;
        }

        public async Task<bool> UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            _context.Update(exerciseType);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            _context.Remove(exerciseType);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
