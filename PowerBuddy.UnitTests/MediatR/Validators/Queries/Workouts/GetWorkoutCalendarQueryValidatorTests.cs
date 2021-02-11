using System;
using System.Linq;
using PowerBuddy.App.Queries.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Workouts
{
    public class GetWorkoutCalendarQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetWorkoutCalendarQueryValidator _validator;

        public GetWorkoutCalendarQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetWorkoutCalendarQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetWorkoutCalendarQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutCalendarQuery(null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutCalendarQuery(""));
            Assert.True(result.Errors.Any());
        }
    }
}