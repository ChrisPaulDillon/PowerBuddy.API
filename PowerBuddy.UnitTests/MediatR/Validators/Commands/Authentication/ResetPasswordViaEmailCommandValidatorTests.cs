using System;
using System.Linq;
using PowerBuddy.App.Commands.Authentication;
using PowerBuddy.App.Commands.Authentication.Models;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Authentication
{
	public class ResetPasswordViaEmailCommandValidatorTests
	{
		private readonly Random _random;
		private readonly ResetPasswordViaEmailCommandValidator _validator;

		private readonly ResetPasswordTokenRequest _changePasswordRequest;

		public ResetPasswordViaEmailCommandValidatorTests()
		{
			_random = new Random();
			_validator = new ResetPasswordViaEmailCommandValidator();
			_changePasswordRequest = new ResetPasswordTokenRequest()
			{
				Token = _random.Next().ToString(),
				Password = _random.Next().ToString()
			};
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new ResetPasswordViaEmailCommand(_changePasswordRequest, _random.Next().ToString()));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PasswordIsNull_ReturnsValidationErrors()
		{
			_changePasswordRequest.Password = null;
			var result = _validator.Validate(new ResetPasswordViaEmailCommand(_changePasswordRequest, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PasswordIsEmpty_ReturnsValidationErrors()
		{
			_changePasswordRequest.Password = string.Empty;
			var result = _validator.Validate(new ResetPasswordViaEmailCommand(_changePasswordRequest, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_TokenIsNull_ReturnsValidationErrors()
		{
			_changePasswordRequest.Token = null;
			var result = _validator.Validate(new ResetPasswordViaEmailCommand(_changePasswordRequest, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_TokenIsEmpty_ReturnsValidationErrors()
		{
			_changePasswordRequest.Token = string.Empty;
			var result = _validator.Validate(new ResetPasswordViaEmailCommand(_changePasswordRequest, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}
	}
}