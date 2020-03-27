using System;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Services.Exercises;
using PowerLifting.Services.LiftingStats;
using PowerLifting.Services.ProgramLogs;
using PowerLifting.Services.TemplatePrograms;
using PowerLifting.Services.Users;

namespace PowerLifting.Repositorys.RepositoryWrappers
{
    public interface IRepositoryWrapper
    {
        
            IUserRepository User { get; }
            ILiftingStatRepository LiftingStat { get; }
            IExerciseRepository Exercise { get; }
            IExerciseCategoryRepository ExerciseCategory { get; }
            IProgramLogRepository ProgramLog { get; }
            ITemplateProgramRepository TemplateProgram { get; }
    }
}
