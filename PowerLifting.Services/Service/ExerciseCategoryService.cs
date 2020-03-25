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
using AutoMapper;
using PowerLifting.Entities.DTOs.Lookups;

namespace Powerlifting.Services.Service
{
    public class ExerciseCategoryService : ServiceBase<ExerciseCategory>, IExerciseCategoryService
    {
        private IMapper _mapper;

        public ExerciseCategoryService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
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
