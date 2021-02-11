using System;
using System.Linq;
using PowerBuddy.App.Queries.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Workouts
{
    public class GetWorkoutWeekByDateQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetWorkoutWeekByDateQueryValidator _validator;

        public GetWorkoutWeekByDateQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetWorkoutWeekByDateQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetWorkoutWeekByDateQuery(DateTime.Now, _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutWeekByDateQuery(DateTime.Now, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetWorkoutWeekByDateQuery(DateTime.Now, ""));
            Assert.True(result.Errors.Any());
        }
    }
}