using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutDays;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutDays
{
    public class UpdateWorkoutDayNotesCommandValidatorTests
    {
        private readonly Random _random;
        private readonly UpdateWorkoutDayNotesCommandValidator _validator;

        public UpdateWorkoutDayNotesCommandValidatorTests()
        {
            _random = new Random();
            _validator = new UpdateWorkoutDayNotesCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new UpdateWorkoutDayNotesCommand(_random.Next(), _random.Next().ToString(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutDayNotesCommand(_random.Next(), _random.Next().ToString(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutDayNotesCommand(_random.Next(), _random.Next().ToString(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutDayIdInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutDayNotesCommand(-55, _random.Next().ToString(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
