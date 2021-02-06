using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutSets;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutSets
{
    public class QuickAddWorkoutSetsCommandValidatorTests
    {
        private readonly Random _random;
        private readonly QuickAddWorkoutSetsCommandValidator _validator;

        public QuickAddWorkoutSetsCommandValidatorTests()
        {
            _random = new Random();
            _validator = new QuickAddWorkoutSetsCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var workoutSets = new List<WorkoutSetDto>()
            {
                new WorkoutSetDto()
            };

            var result = _validator.Validate(new QuickAddWorkoutSetsCommand(workoutSets, _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutSets = new List<WorkoutSetDto>() { new WorkoutSetDto() };
            var result = _validator.Validate(new QuickAddWorkoutSetsCommand(workoutSets, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutSets = new List<WorkoutSetDto>() { new WorkoutSetDto() };
            var result = _validator.Validate(new QuickAddWorkoutSetsCommand(workoutSets, ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutSetIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new QuickAddWorkoutSetsCommand(null, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutSetIsEmpty_ReturnsValidationErrors()
        {
            var workoutSets = new List<WorkoutSetDto>();
            var result = _validator.Validate(new QuickAddWorkoutSetsCommand(workoutSets, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
