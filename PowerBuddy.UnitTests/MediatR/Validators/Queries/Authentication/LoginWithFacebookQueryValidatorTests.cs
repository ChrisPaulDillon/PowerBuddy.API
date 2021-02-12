using System;
using System.Linq;
using PowerBuddy.App.Queries.Authentication;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Authentication
{
	public class LoginWithFacebookQueryValidatorTests
	{
		private readonly Random _random;
		private readonly LoginWithFacebookQueryValidator _validator;

		public LoginWithFacebookQueryValidatorTests()
		{
			_random = new Random();
			_validator = new LoginWithFacebookQueryValidator();
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new LoginWithFacebookQuery(_random.Next().ToString()));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_AccessTokenIsNull_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new LoginWithFacebookQuery(null));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_AccessTokenIsEmpty_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new LoginWithFacebookQuery(""));
			Assert.True(result.Errors.Any());
		}
	}
}