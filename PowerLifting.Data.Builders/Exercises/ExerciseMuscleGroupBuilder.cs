using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Builders.Exercises
{
    public class ExerciseMuscleGroupBuilder
    {
        private readonly Random _random;
        private readonly ExerciseMuscleGroupAssoc _exerciseMuscleGroup;

        public ExerciseMuscleGroupBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _exerciseMuscleGroup = new ExerciseMuscleGroupAssoc()
            {
                ExerciseMuscleGroupAssocId =  _random.Next(),
                ExerciseMuscleGroupName = _random.Next().ToString(),
                ExerciseId = _random.Next(),
            };
        }

        public ExerciseMuscleGroupAssoc Build()
        {
            return _exerciseMuscleGroup;
        }

        public ExerciseMuscleGroupBuilder WithExerciseMuscleGroupId(int exerciseMuscleGroupId)
        {
            _exerciseMuscleGroup.ExerciseMuscleGroupAssocId = exerciseMuscleGroupId;
            return this;
        }

        public ExerciseMuscleGroupBuilder WithExerciseMuscleGroupName(string exerciseMuscleGroupName)
        {
            _exerciseMuscleGroup.ExerciseMuscleGroupName = exerciseMuscleGroupName;
            return this;
        }

        public ExerciseMuscleGroupBuilder WithExerciseId(int exerciseId)
        {
            _exerciseMuscleGroup.ExerciseId = exerciseId;
            return this;
        }
    }
}
