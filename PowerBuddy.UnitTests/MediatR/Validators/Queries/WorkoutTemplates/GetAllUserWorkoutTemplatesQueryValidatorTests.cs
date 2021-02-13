using System;
using System.Linq;
using PowerBuddy.App.Queries.WorkoutTemplates;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.WorkoutTemplates
{
    public class GetAllUserWorkoutTemplatesQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetAllUserWorkoutTemplatesQueryValidator _validator;

        public GetAllUserWorkoutTemplatesQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetAllUserWorkoutTemplatesQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetAllUserWorkoutTemplatesQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetAllUserWorkoutTemplatesQuery(null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetAllUserWorkoutTemplatesQuery(""));
            Assert.True(result.Errors.Any());
        }
    }
}