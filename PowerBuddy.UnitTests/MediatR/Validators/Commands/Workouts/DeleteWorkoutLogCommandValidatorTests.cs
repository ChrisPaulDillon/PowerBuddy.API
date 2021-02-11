using System;
using System.Linq;
using PowerBuddy.App.Commands.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Workouts
{
    public class DeleteWorkoutLogCommandValidatorTests
    {
        private readonly Random _random;
        private readonly DeleteWorkoutLogCommandValidator _validator;

        public DeleteWorkoutLogCommandValidatorTests()
        {
            _random = new Random();
            _validator = new DeleteWorkoutLogCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new DeleteWorkoutLogCommand(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutLogCommand(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutLogCommand(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidWorkoutLogId_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutLogCommand(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
