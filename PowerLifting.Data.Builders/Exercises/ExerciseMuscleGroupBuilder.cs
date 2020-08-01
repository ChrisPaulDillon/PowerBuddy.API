using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.Builders.Exercises
{
    public class ExerciseMuscleGroupBuilder
    {
        private readonly Random _random;
        private readonly ExerciseMuscleGroup _exerciseMuscleGroup;

        public ExerciseMuscleGroupBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _exerciseMuscleGroup = new ExerciseMuscleGroup()
            {
                ExerciseMuscleGroupId = _random.Next(),
                ExerciseMuscleGroupName = _random.Next().ToString(),
                ExerciseId = _random.Next(),
            };
        }

        public ExerciseMuscleGroup Build()
        {
            return _exerciseMuscleGroup;
        }

        public ExerciseMuscleGroupBuilder WithExerciseMuscleGroupId(int exerciseMuscleGroupId)
        {
            _exerciseMuscleGroup.ExerciseMuscleGroupId = exerciseMuscleGroupId;
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
