using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.Dtos.Workouts;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutTemplates
{
    public class CreateWorkoutTemplatesCommandValidatorTests
    {
        private readonly Random _random;
        private readonly CreateWorkoutTemplateCommandValidator _validator;

        public CreateWorkoutTemplatesCommandValidatorTests()
        {
            _random = new Random();
            _validator = new CreateWorkoutTemplateCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithWorkoutExercises(new List<WorkoutExerciseDto>() { new WorkoutExerciseDto()
            {
                WorkoutSets = new List<WorkoutSetDto>() { new WorkoutSetDto()}
            }}).Build();

            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, null));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, ""));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutNameIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithTemplateName("").Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutNameIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithTemplateName(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutExercisesIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithWorkoutExercises(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutExercisesHasNoSets_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithWorkoutExercises(new List<WorkoutExerciseDto>() { new WorkoutExerciseDto() }).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithUserId(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithUserId("").Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }
    }
}
