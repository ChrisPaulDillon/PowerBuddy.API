using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.Data.Builders.DTOs.Workouts
{
    public class WorkoutTemplateDTOBuilder
    {
        private readonly Random _random;
        private readonly WorkoutTemplateDTO _workoutTemplateDTO;

        public WorkoutTemplateDTOBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _workoutTemplateDTO = new WorkoutTemplateDTO
            {
                WorkoutTemplateId = _random.Next(),
                WorkoutName = _random.Next().ToString(),
                DateCreated = DateTime.UtcNow,
                UserId = _random.Next().ToString(),
                WorkoutExercises = new List<WorkoutExerciseDTO>()
            };
        }

        public WorkoutTemplateDTO Build()
        {
            return _workoutTemplateDTO;
        }

        public WorkoutTemplateDTOBuilder WithWorkoutTemplateId(int workoutTemplateId)
        {
            _workoutTemplateDTO.WorkoutTemplateId = workoutTemplateId;
            return this;
        }

        public WorkoutTemplateDTOBuilder WithTemplateName(string workoutName)
        {
            _workoutTemplateDTO.WorkoutName = workoutName;
            return this;
        }

        public WorkoutTemplateDTOBuilder WithCreatedDate(DateTime createdDate)
        {
            _workoutTemplateDTO.DateCreated = createdDate;
            return this;
        }

        public WorkoutTemplateDTOBuilder WithUserId(string userId)
        {
            _workoutTemplateDTO.UserId = userId;
            return this;
        }

        public WorkoutTemplateDTOBuilder WithWorkoutExercises(IEnumerable<WorkoutExerciseDTO> workoutExercises)
        {
            _workoutTemplateDTO.WorkoutExercises = workoutExercises;
            return this;
        }
    }
}
