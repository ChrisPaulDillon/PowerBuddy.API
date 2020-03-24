using System;
using System.Collections.Generic;
using System.Text;
using Powerlifting.Contracts.Contracts;

namespace Powerlifting.Contracts
{
    public interface IServiceWrapper
    {
        IUserService User { get; }
        ILiftingStatService LiftingStat { get; }
        IExerciseService Exercise { get; }
        IExerciseCategoryService ExerciseCategory { get; }
        IProgramLogService ProgramLog { get; }
        IProgramTypeService ProgramType { get; }
        void Save();
    }
}
