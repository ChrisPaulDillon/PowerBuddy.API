using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Persistence;

namespace PowerLifting.Exercises.Service
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseTypeService(PowerLiftingContext context, IMapper mapper)
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
            var exerciseType = await _context.Set<ExerciseType>()
                .Where(c => c.ExerciseTypeId == exerciseTypeId)
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (exerciseType == null) throw new ExerciseTypeNotFoundException();

            return exerciseType;
        }

        public async Task<bool> UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var doesTypeExist = await _context.ExerciseType
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseTypeId == exerciseTypeDTO.ExerciseTypeId);

            if (!doesTypeExist) throw new ExerciseTypeNotFoundException();

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);

            _context.Update(exerciseType);
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<bool> DeleteExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var doesTypeExist = await _context.ExerciseType
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseTypeId == exerciseTypeDTO.ExerciseTypeId);

            if (!doesTypeExist) throw new ExerciseTypeNotFoundException();

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);

            _context.Remove(exerciseType);
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<ExerciseTypeDTO> CreateExerciseType(ExerciseTypeDTO exerciseTypeDTO)
        {
            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            _context.Add(exerciseType);
            await _context.SaveChangesAsync();
            return exerciseTypeDTO;
        }
    }
}