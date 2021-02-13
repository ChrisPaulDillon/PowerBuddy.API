using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.DTOs.WorkoutTemplates;

namespace PowerBuddy.Data.Builders.Dtos.Workouts
{
    public class WorkoutTemplateDtoBuilder
    {
        private readonly Random _random;
        private readonly WorkoutTemplateDto _workoutTemplateDto;

        public WorkoutTemplateDtoBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _workoutTemplateDto = new WorkoutTemplateDto
            {
                WorkoutTemplateId = _random.Next(),
                WorkoutName = _random.Next().ToString(),
                DateCreated = DateTime.UtcNow,
                UserId = _random.Next().ToString(),
                WorkoutExercises = new List<WorkoutExerciseDto>()
            };
        }

        public WorkoutTemplateDto Build()
        {
            return _workoutTemplateDto;
        }

        public WorkoutTemplateDtoBuilder WithWorkoutTemplateId(int workoutTemplateId)
        {
            _workoutTemplateDto.WorkoutTemplateId = workoutTemplateId;
            return this;
        }

        public WorkoutTemplateDtoBuilder WithTemplateName(string workoutName)
        {
            _workoutTemplateDto.WorkoutName = workoutName;
            return this;
        }

        public WorkoutTemplateDtoBuilder WithCreatedDate(DateTime createdDate)
        {
            _workoutTemplateDto.DateCreated = createdDate;
            return this;
        }

        public WorkoutTemplateDtoBuilder WithUserId(string userId)
        {
            _workoutTemplateDto.UserId = userId;
            return this;
        }

        public WorkoutTemplateDtoBuilder WithWorkoutExercises(IEnumerable<WorkoutExerciseDto> workoutExercises)
        {
            _workoutTemplateDto.WorkoutExercises = workoutExercises;
            return this;
        }
    }
}
