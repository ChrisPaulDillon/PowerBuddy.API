using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutExercises;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutExercises
{
    public class CreateWorkoutExerciseCommandValidatorTests
    {
        private readonly Random _random;
        private readonly CreateWorkoutExerciseCommandValidator _validator;

        public CreateWorkoutExerciseCommandValidatorTests()
        {
            _random = new Random();
            _validator = new CreateWorkoutExerciseCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidWorkoutDayId_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().WithWorkoutDayId(-55).Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidExerciseId_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().WithExerciseId(-55).Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidSets_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().WithSets(-55).Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidReps_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().WithReps(-55).Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidWeight_ReturnsValidationErrors()
        {
            var workoutExercise = new CreateWorkoutExerciseDtoBuilder().WithWeight(-55).Build();
            var result = _validator.Validate(new CreateWorkoutExerciseCommand(workoutExercise, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
