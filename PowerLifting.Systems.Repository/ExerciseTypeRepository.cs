using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Powerlifting.Common;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseTypeRepository : RepositoryBase<ExerciseType>, IExerciseTypeRepository
    {
        private readonly IMapper _mapper;
        public ExerciseTypeRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes()
        {
            return await PowerliftingContext.Set<ExerciseType>()
                .AsNoTracking()
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseType>()
                .AsNoTracking()
                .Where(c => c.ExerciseTypeId == exerciseTypeId)
                .ProjectTo<ExerciseTypeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public void UpdateExerciseType(ExerciseType exerciseType)
        {
            Update(exerciseType);
        }

        public void DeleteExerciseType(ExerciseType exerciseType)
        {
            Delete(exerciseType);
        }
    }
}
