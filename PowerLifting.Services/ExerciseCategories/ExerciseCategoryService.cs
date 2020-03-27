﻿using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using PowerLifting.Entities.DTOs.Lookups;
using System.Collections.Concurrent;
using Powerlifting.Services.ExerciseCategories.Model;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Repositorys.RepositoryWrappers;

namespace Powerlifting.Service.ExerciseCategories
{
    public class ExerciseCategoryService : IExerciseCategoryService
    {
        private IMapper _mapper;
        private ConcurrentDictionary<int, ExerciseCategoryDTO> _store;
        private IRepositoryWrapper _repo;

        public ExerciseCategoryService(IRepositoryWrapper repo, IMapper mapper)
        {
            _store = new ConcurrentDictionary<int, ExerciseCategoryDTO>();
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ExerciseCategoryDTO> GetAllCategories()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        private void RefreshExerciseStore()
        {
            if (!_store.IsEmpty)
                return;

            var categories = _repo.ExerciseCategory.GetAllCategories();
            var categoryDTOs = _mapper.Map<IEnumerable<ExerciseCategoryDTO>>(categories);

            foreach (var exerciseDTO in categoryDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseCategoryId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseCategoryDTO> GetExerciseCategoryById(int id)
        {
            var exerciseCategory = await _repo.ExerciseCategory.GetCategoryById(id);
            var exerciseCategoryDTO = _mapper.Map<ExerciseCategoryDTO>(exerciseCategory);
            return exerciseCategoryDTO;
        }

        public void UpdateExerciseCategory(ExerciseCategoryDTO exerciseCategory)
        {
            var exerciseEntity = _mapper.Map<ExerciseCategory>(exerciseCategory);
            _repo.ExerciseCategory.UpdateCategory(exerciseEntity);
        }

        public void DeleteExerciseCategory(ExerciseCategoryDTO exerciseCategory)
        {
            var exerciseEntity = _mapper.Map<ExerciseCategory>(exerciseCategory);
            _repo.ExerciseCategory.UpdateCategory(exerciseEntity);
        }

        public Task<ExerciseCategoryDTO> GetExerciseCategoryByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
