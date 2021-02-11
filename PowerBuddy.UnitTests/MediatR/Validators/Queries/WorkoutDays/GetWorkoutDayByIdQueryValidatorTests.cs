using System;
using System.Linq;
using PowerBuddy.App.Queries.WorkoutDays;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.WorkoutDays
{
    public class GetWorkoutDayByIdQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetWorkoutDayByIdQueryValidator _validator;

        public GetWorkoutDayByIdQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetWorkoutDayByIdQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetWorkoutDayByIdQuery(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutDayByIdQuery(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutDayByIdQuery(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutDayIdInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutDayByIdQuery(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}