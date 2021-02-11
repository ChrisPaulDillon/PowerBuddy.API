using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutExercises;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutExercises
{
    public class DeleteWorkoutExerciseCommandValidatorTests
    {
        private readonly Random _random;
        private readonly DeleteWorkoutExerciseCommandValidator _validator;

        public DeleteWorkoutExerciseCommandValidatorTests()
        {
            _random = new Random();
            _validator = new DeleteWorkoutExerciseCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new DeleteWorkoutExerciseCommand(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutExerciseCommand(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutExerciseCommand(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidWorkoutExerciseId_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutExerciseCommand(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}