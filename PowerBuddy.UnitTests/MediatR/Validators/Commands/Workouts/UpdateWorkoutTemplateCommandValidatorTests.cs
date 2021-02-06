using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.Dtos.Workouts;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Workouts
{
    public class UpdateWorkoutTemplatesCommandValidatorTests
    {
        private readonly Random _random;
        private readonly UpdateWorkoutTemplateCommandValidator _validator;

        public UpdateWorkoutTemplatesCommandValidatorTests()
        {
            _random = new Random();
            _validator = new UpdateWorkoutTemplateCommandValidator();
        }

        [Fact]
        public void UpdateNew_ValidParameters_Passes()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithWorkoutExercises(new List<WorkoutExerciseDto>() { new WorkoutExerciseDto() }).Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, null));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, ""));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutNameIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithTemplateName("").Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutNameIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithTemplateName(null).Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutExercisesIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithWorkoutExercises(null).Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutUserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithUserId(null).Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void UpdateNew_WorkoutUserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDtoBuilder().WithUserId("").Build();
            var result = _validator.Validate(new UpdateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }
    }
}
