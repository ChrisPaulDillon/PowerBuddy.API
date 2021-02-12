using System;
using System.Linq;
using PowerBuddy.App.Commands.Authentication;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Authentication
{
	public class RefreshTokenCommandValidatorTests
	{
		private readonly Random _random;
		private readonly RefreshTokenCommandValidator _validator;

		public RefreshTokenCommandValidatorTests()
		{
			_random = new Random();
			_validator = new RefreshTokenCommandValidator();
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new RefreshTokenCommand(_random.Next().ToString()));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_RefreshTokenIsNull_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new RefreshTokenCommand(null));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_RefreshTokenIsEmpty_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new RefreshTokenCommand(string.Empty));
			Assert.True(result.Errors.Any());
		}
	}
}