using System;
using System.Linq;
using PowerBuddy.App.Queries.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Workouts
{
    public class GetAllWorkoutStatsQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetAllWorkoutStatsQueryValidator _validator;

        public GetAllWorkoutStatsQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetAllWorkoutStatsQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetAllWorkoutStatsQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetAllWorkoutStatsQuery(null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetAllWorkoutStatsQuery(""));
            Assert.True(result.Errors.Any());
        }
    }
}