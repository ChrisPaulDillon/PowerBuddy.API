using System.Collections.Generic;
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
    public class ExerciseMuscleGroupService : IExerciseMuscleGroupService
    {
        private readonly IMapper _mapper;
        private readonly PowerLiftingContext _context;

        public ExerciseMuscleGroupService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups()
        {
         
        }

        public async Task<bool> UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var doesMuscleGroupExist = await _context.ExerciseMuscleGroup
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseMuscleGroupId == exerciseMuscleGroupDTO.ExerciseMuscleGroupId);
            
            if (!doesMuscleGroupExist) throw new ExerciseMuscleGroupNotFoundException();

            var exerciseMuscleGroup = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroupDTO);

            _context.Update(exerciseMuscleGroup);
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<bool> DeleteExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO)
        {
            var doesMuscleGroupExist = await _context.ExerciseMuscleGroup
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseMuscleGroupId == exerciseMuscleGroupDTO.ExerciseMuscleGroupId);

            if (!doesMuscleGroupExist) throw new ExerciseMuscleGroupNotFoundException();

            var exerciseMuscleGroup = _mapper.Map<ExerciseMuscleGroup>(exerciseMuscleGroupDTO);

            _context.Remove(exerciseMuscleGroup);
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }
    }
}