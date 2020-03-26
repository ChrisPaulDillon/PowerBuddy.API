﻿using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using AutoMapper;
using Powerlifting.Services.ServiceWrappers;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;

namespace Powerlifting.Service.Exercises
{
    public class ExerciseService : ServiceBase<Exercise>, IExerciseService
    {
        private ConcurrentDictionary<int, ExerciseDTO> _store;
        private IMapper _mapper;

        public ExerciseService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _store = new ConcurrentDictionary<int, ExerciseDTO>();
            _mapper = mapper;
        }

        public IEnumerable<ExerciseDTO> GetAllExercises()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        private void RefreshExerciseStore()
        {
            if(!_store.IsEmpty)
                return;
            
            var exercises = PowerliftingContext.Set<Exercise>().Include(x => x.ExerciseCategory).ToList();
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

        public void UpdateExercise(Exercise exercise)
        {
            Update(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            Delete(exercise);
        }

        public Task<ExerciseDTO> GetExerciseByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateExercie(ExerciseDTO exercise)
        {
            throw new NotImplementedException();
        }

        void IExerciseService.RefreshExerciseStore()
        {
            throw new NotImplementedException();
        }
    }
}
