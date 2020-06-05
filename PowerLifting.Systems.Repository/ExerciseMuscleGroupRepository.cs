using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
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
    public class ExerciseMuscleGroupRepository : RepositoryBase<ExerciseMuscleGroup>, IExerciseMuscleGroupRepository
    {
        private readonly IMapper _mapper;
        public ExerciseMuscleGroupRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups()
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>().AsNoTracking()
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>()
                .Where(c => c.ExerciseMuscleGroupId == exerciseTypeId)
                .ProjectTo<ExerciseMuscleGroupDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public void UpdateExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Update(exerciseMuscleGroup);
        }

        public void DeleteExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Delete(exerciseMuscleGroup);
        }
    }
}
