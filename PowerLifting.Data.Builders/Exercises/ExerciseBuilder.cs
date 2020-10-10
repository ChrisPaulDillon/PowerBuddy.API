using System;
using System.Collections.Generic;
using System.Text;
using Exercise = PowerLifting.Data.Entities.Exercise;

namespace PowerLifting.Data.Builders.Exercises
{
    public class ExerciseBuilder
    {
        private readonly Random _random;
        private readonly Exercise _exercise;

        public ExerciseBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _exercise = new Exercise
            {
                ExerciseId = _random.Next(),
                ExerciseTypeId = _random.Next(),
                ExerciseName = _random.Next().ToString(),
                IsApproved = true
            };
        }

        public Exercise Build()
        {
            return _exercise;
        }

        public ExerciseBuilder WithExerciseId(int exerciseId)
        {
            _exercise.ExerciseId = exerciseId;
            return this;
        }

        public ExerciseBuilder WithExerciseName(string exerciseName)
        {
            _exercise.ExerciseName = exerciseName;
            return this;
        }

        public ExerciseBuilder WithExerciseTypeId(int exerciseTypeId)
        {
            _exercise.ExerciseTypeId = exerciseTypeId;
            return this;
        }

        public ExerciseBuilder WithIsApproved(bool isApproved)
        {
            _exercise.IsApproved = isApproved;
            return this;
        }
    }
}
