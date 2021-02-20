using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
    public class WorkoutTemplateBuilder
    {
        private readonly Random _random;
        private readonly WorkoutTemplate _workoutTemplate;

        public WorkoutTemplateBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _workoutTemplate = new WorkoutTemplate
            {
                WorkoutTemplateId = _random.Next(),
                WorkoutName = _random.Next().ToString(),
                DateCreated = DateTime.UtcNow,
                UserId = _random.Next().ToString(),
                WorkoutExercises = new List<WorkoutExercise>()
            };
        }

        public WorkoutTemplate Build()
        {
            return _workoutTemplate;
        }

        public WorkoutTemplateBuilder WithWorkoutTemplateId(int workoutTemplateId)
        {
            _workoutTemplate.WorkoutTemplateId = workoutTemplateId;
            return this;
        }

        public WorkoutTemplateBuilder WithTemplateName(string workoutName)
        {
            _workoutTemplate.WorkoutName = workoutName;
            return this;
        }

        public WorkoutTemplateBuilder WithCreatedDate(DateTime createdDate)
        {
            _workoutTemplate.DateCreated = createdDate;
            return this;
        }

        public WorkoutTemplateBuilder WithUserId(string userId)
        {
            _workoutTemplate.UserId = userId;
            return this;
        }

        public WorkoutTemplateBuilder WithWorkoutExercises(IEnumerable<WorkoutExercise> workoutExercises)
        {
            _workoutTemplate.WorkoutExercises = workoutExercises;
            return this;
        }
    }
}
