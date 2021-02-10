using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutSets;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutSets
{
    public class UpdateWorkoutSetCommandValidatorTests
    {
        private readonly Random _random;
        private readonly UpdateWorkoutSetCommandValidator _validator;

        public UpdateWorkoutSetCommandValidatorTests()
        {
            _random = new Random();
            _validator = new UpdateWorkoutSetCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var workoutSet = new WorkoutSetDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutDayIdInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(-55, workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutSetIdInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().WithWorkoutSetId(0).Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutExerciseIdInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().WithWorkoutExerciseId(0).Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutNoOfRepsInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().WithNoOfReps(0).Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutRepsCompletedInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().WithRepsCompleted(-1).Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutWeightLiftedInvalid_ReturnsValidationErrors()
        {
            var workoutSet = new WorkoutSetDtoBuilder().WithWeightLifted(-1).Build();
            var result = _validator.Validate(new UpdateWorkoutSetCommand(_random.Next(), workoutSet, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
