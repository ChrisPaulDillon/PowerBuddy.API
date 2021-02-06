using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutSets;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutSets
{
    public class DeleteWorkoutSetCommandValidatorTests
    {
        private readonly Random _random;
        private readonly DeleteWorkoutSetCommandValidator _validator;

        public DeleteWorkoutSetCommandValidatorTests()
        {
            _random = new Random();
            _validator = new DeleteWorkoutSetCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new DeleteWorkoutSetCommand(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutSetCommand(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutSetCommand(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutSetIdInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutSetCommand(-55, ""));
            Assert.True(result.Errors.Any());
        }
    }
}
