using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutDays;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutDays
{
	public class CompleteWorkoutCommandValidatorTests
    {
        private readonly Random _random;
        private readonly CompleteWorkoutCommandValidator _validator;

        public CompleteWorkoutCommandValidatorTests()
        {
            _random = new Random();
            _validator = new CompleteWorkoutCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var workoutSets = new List<WorkoutSetDto>()
            {
                new WorkoutSetDto()
            };

            var workoutDayDto = new WorkoutDayDtoBuilder().WithWorkoutExercises(new List<WorkoutExerciseDto>() { new WorkoutExerciseDto()
		            {
			            WorkoutSets = workoutSets
		            }

            }).Build();
            var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutDayIdInvalid_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().WithWorkoutDayId(-55).Build();
	        var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, _random.Next().ToString()));
	        Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().Build();
            var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().Build();
            var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNullInDto_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().WithUserId(null).Build();
	        var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, _random.Next().ToString()));
	        Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmptyInDto_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().WithUserId("").Build();
	        var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, _random.Next().ToString()));
	        Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutSetIsEmpty_ReturnsValidationErrors()
        {
	        var workoutDayDto = new WorkoutDayDtoBuilder().WithWorkoutExercises(new List<WorkoutExerciseDto>()).Build();
            var result = _validator.Validate(new CompleteWorkoutCommand(workoutDayDto, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
