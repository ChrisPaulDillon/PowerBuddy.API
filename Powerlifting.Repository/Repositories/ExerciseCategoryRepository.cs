using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Services.ExerciseCategories.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ExerciseCategories;

namespace PowerLifting.Repository.Repositories
{
    public class ExerciseCategoryRepository : RepositoryBase<ExerciseCategory>, IExerciseCategoryRepository
    {
        public ExerciseCategoryRepository(PowerliftingContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ExerciseCategory>> GetAllCategories()
        {
            return await PowerliftingContext.Set<ExerciseCategory>().ToListAsync();
        }

        public async Task<ExerciseCategory> GetCategoryById(int id)
        {
            return await PowerliftingContext.Set<ExerciseCategory>().Where(c => c.ExerciseCategoryId == id).FirstOrDefaultAsync();
        }

        public void UpdateCategory(ExerciseCategory category)
        {
            Update(category);
            Save();
        }

        public void DeleteCategory(ExerciseCategory category)
        {
            Delete(category);
            Save(); 
        }
    }
}
