using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using PowerBuddy.Data.DTOs.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Workouts
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
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithWorkoutExercises(new List<WorkoutExerciseDTO>() { new WorkoutExerciseDTO()}).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, null));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, ""));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutNameIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithTemplateName("").Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutNameIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithTemplateName(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutExercisesIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithWorkoutExercises(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsNull_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithUserId(null).Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutTemplate = new WorkoutTemplateDTOBuilder().WithUserId("").Build();
            var result = _validator.Validate(new CreateWorkoutTemplateCommand(workoutTemplate, _random.Next().ToString()));

            Assert.True(result.Errors.Any());
        }
    }
}
