using System;
using System.Linq;
using PowerBuddy.App.Queries.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Workouts
{
    public class GetWorkoutLogByIdQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetWorkoutLogByIdQueryValidator _validator;

        public GetWorkoutLogByIdQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetWorkoutLogByIdQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetWorkoutLogByIdQuery(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutLogByIdQuery(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutLogByIdQuery(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutLogIdInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutLogByIdQuery(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}