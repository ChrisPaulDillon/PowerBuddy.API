using System;
using System.Linq;
using PowerBuddy.App.Commands.Authentication;
using PowerBuddy.App.Commands.Sms;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Authentication
{
	public class SendSmsVerificationCommandValidatorTests
	{
		private readonly Random _random;
		private readonly SendSmsVerificationCommandValidator _validator;


		public SendSmsVerificationCommandValidatorTests()
		{
			_random = new Random();
			_validator = new SendSmsVerificationCommandValidator();
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new SendSmsVerificationCommand(_random.Next().ToString(), _random.Next().ToString()));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PhoneNumberIsNull_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new SendSmsVerificationCommand(null, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PhoneNumberIsEmpty_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new SendSmsVerificationCommand(string.Empty, _random.Next().ToString()));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new SendSmsVerificationCommand(_random.Next().ToString(),null));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
		{
			var result = _validator.Validate(new SendSmsVerificationCommand(_random.Next().ToString(), string.Empty));
			Assert.True(result.Errors.Any());
		}
	}
}