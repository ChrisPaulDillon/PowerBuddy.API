using System;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Builders.DTOs.Workouts
{
    public class CreateWorkoutExerciseDtoBuilder
    {
        private readonly Random _random;
        private readonly CreateWorkoutExerciseDto _workoutExercise;

        public CreateWorkoutExerciseDtoBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _workoutExercise = new CreateWorkoutExerciseDto
            {
                ExerciseId = _random.Next(),
                WorkoutDayId = _random.Next(),
                Sets = _random.Next(),
                Reps = _random.Next(),
                Weight = _random.Next()
            };
        }

        public CreateWorkoutExerciseDto Build()
        {
            return _workoutExercise;
        }

        public CreateWorkoutExerciseDtoBuilder WithSets(int sets)
        {
            _workoutExercise.Sets = sets;
            return this;
        }

        public CreateWorkoutExerciseDtoBuilder WithReps(int reps)
        {
            _workoutExercise.Reps = reps;
            return this;
        }

        public CreateWorkoutExerciseDtoBuilder WithWeight(decimal weight)
        {
            _workoutExercise.Weight = weight;
            return this;
        }

        public CreateWorkoutExerciseDtoBuilder WithWorkoutDayId(int workoutDayId)
        {
            _workoutExercise.WorkoutDayId = workoutDayId;
            return this;
        }

        public CreateWorkoutExerciseDtoBuilder WithExerciseId(int exerciseId)
        {
            _workoutExercise.ExerciseId = exerciseId;
            return this;
        }
    }
}
