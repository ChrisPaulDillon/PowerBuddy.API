using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;
using Powerlifting.Services;
using System.Collections.Generic;
using PowerLifting.Entities.Model.Lookups;
using Powerlifting.Contracts;
using System.Linq.Expressions;
using System;
using PowerLifting.Entities.DTOs.Lookups;
using System.Collections.Concurrent;
using AutoMapper;

namespace Powerlifting.Services.Service
{
    public class ExerciseService : ServiceBase<ExerciseDTO>, IExerciseService
    {
        private ConcurrentDictionary<int, ExerciseDTO> _store;
        private IMapper _mapper;

        public ExerciseService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        private void RefreshExerciseStore()
        {
            if(_store.IsEmpty)
                return;
            
            var exercises = PowerliftingContext.Set<Exercise>().Include(x => x.ExerciseCategory).ToListAsync();
            var exerciseDTOs = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);

            foreach(var exerciseDTO in exerciseDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var exercise = await PowerliftingContext.Set<Exercise>().Where(x => x.ExerciseId == id).Include(x => x.ExerciseCategory).AsNoTracking().FirstOrDefaultAsync();
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public void UpdateExercie(ExerciseDTO exercise)
        {
            Update(exercise);
        }

        public void DeleteExercise(ExerciseDTO exercise)
        {
            Delete(exercise);
        }
    }
}
