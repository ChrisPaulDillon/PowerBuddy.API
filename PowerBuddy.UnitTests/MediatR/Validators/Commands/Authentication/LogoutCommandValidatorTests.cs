using System;
using System.Linq;
using PowerBuddy.App.Commands.Authentication;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Authentication
{
	public class LogoutCommandValidatorTests
	{
		private readonly Random _random;
		private readonly LogoutCommandValidator _validator;

		public LogoutCommandValidatorTests()
		{
			_random = new Random();
			_validator = new LogoutCommandValidator();
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new LogoutCommand(_random.Next().ToString()));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_RefreshTokenIsNull_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new LogoutCommand(null));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_RefreshTokenIsEmpty_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new LogoutCommand(string.Empty));
			Assert.True(result.Errors.Any());
		}
	}
}