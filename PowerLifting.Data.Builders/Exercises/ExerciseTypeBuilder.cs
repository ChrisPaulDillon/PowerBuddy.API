using PowerLifting.Data.Entities.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Builders.Exercises
{
    public class ExerciseTypeBuilder
    {
        private readonly Random _random;
        private readonly ExerciseType _exerciseType;

        public ExerciseTypeBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _exerciseType = new ExerciseType
            {
                ExerciseTypeId = _random.Next(),
                ExerciseTypeName = _random.Next().ToString(),
            };
        }

        public ExerciseType Build()
        {
            return _exerciseType;
        }

        public ExerciseTypeBuilder WithExerciseId(int exerciseTypeId)
        {
            _exerciseType.ExerciseTypeId = exerciseTypeId;
            return this;
        }

        public ExerciseTypeBuilder WithExerciseTypeName(string exerciseTypeName)
        {
            _exerciseType.ExerciseTypeName = exerciseTypeName;
            return this;
        }
    }
}
