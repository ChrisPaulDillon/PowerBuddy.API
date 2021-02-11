using System;
using System.Linq;
using PowerBuddy.App.Queries.Users;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Users
{
    public class GetPublicUserProfileByUsernameQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetPublicUserProfileByUsernameQueryValidator _validator;

        public GetPublicUserProfileByUsernameQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetPublicUserProfileByUsernameQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetPublicUserProfileByUsernameQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetPublicUserProfileByUsernameQuery(null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetPublicUserProfileByUsernameQuery(""));
            Assert.True(result.Errors.Any());
        }
    }
}