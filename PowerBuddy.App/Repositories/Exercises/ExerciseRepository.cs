using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.App.Repositories.Exercises
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDto>> GetAllExercises()
        {
            return await _context.Exercise
                .AsNoTracking()
                .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDto>> GetAllExerciseMuscleGroups()
        {
            return await _context.ExerciseMuscleGroup
                .AsNoTracking()
                .ProjectTo<ExerciseMuscleGroupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseTypeDto>> GetAllExerciseTypes()
        {
            return await _context.ExerciseType
                .ProjectTo<ExerciseTypeDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
