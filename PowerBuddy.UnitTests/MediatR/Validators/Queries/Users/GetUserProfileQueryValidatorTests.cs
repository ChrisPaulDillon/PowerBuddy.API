using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.App.Queries.Users;
using PowerBuddy.App.Queries.WorkoutDays;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Users
{
    public class GetUserProfileQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetUserProfileQueryValidator _validator;

        public GetUserProfileQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetUserProfileQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetUserProfileQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetUserProfileQuery(null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetUserProfileQuery(""));
            Assert.True(result.Errors.Any());
        }
    }
}