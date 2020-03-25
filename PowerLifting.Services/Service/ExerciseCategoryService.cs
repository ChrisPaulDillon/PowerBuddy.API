using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Persistence;
using System.Collections.Generic;
using PowerLifting.Entities.Model.Lookups;
using System;
using AutoMapper;
using PowerLifting.Entities.DTOs.Lookups;
using System.Collections.Concurrent;

namespace Powerlifting.Services.Service
{
    public class ExerciseCategoryService : ServiceBase<ExerciseCategory>, IExerciseCategoryService
    {
        private IMapper _mapper;
        private ConcurrentDictionary<int, ExerciseCategoryDTO> _store;

        public ExerciseCategoryService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public IEnumerable<ExerciseCategoryDTO> GetAllCategories()
        {
            RefreshExerciseStore();
            return _store.Values;
        }

        private void RefreshExerciseStore()
        {
            if (_store.IsEmpty)
                return;

            var categories = PowerliftingContext.Set<ExerciseCategory>().ToListAsync();
            var categoryDTOs = _mapper.Map<IEnumerable<ExerciseCategoryDTO>>(categories);

            foreach (var exerciseDTO in categoryDTOs)
            {
                _store.AddOrUpdate(exerciseDTO.ExerciseCategoryId, exerciseDTO, (key, olValue) => exerciseDTO);
            }
        }

        public async Task<ExerciseCategoryDTO> GetExerciseCategoryById(int id)
        {
            var exerciseCategory = await PowerliftingContext.Set<ExerciseCategory>().Where(c => c.ExerciseCategoryId == id).FirstOrDefaultAsync();
            var exerciseCategoryDTO = _mapper.Map<ExerciseCategoryDTO>(exerciseCategory);
            return exerciseCategoryDTO;
        }

        public async Task<ExerciseCategory> GetExerciseCategoryByName(string categoryName)
        {
            return await PowerliftingContext.Set<ExerciseCategory>().Where(exerciseCategory => exerciseCategory.CategoryName == categoryName).FirstOrDefaultAsync();
        }

        public void UpdateExerciseCategory(ExerciseCategory exerciseCategory)
        {
            Update(exerciseCategory);
        }

        public void DeleteExerciseCategory(ExerciseCategory exerciseCategory)
        {
            Delete(exerciseCategory);
        }

        Task<ExerciseCategoryDTO> IExerciseCategoryService.GetExerciseCategoryByName(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
