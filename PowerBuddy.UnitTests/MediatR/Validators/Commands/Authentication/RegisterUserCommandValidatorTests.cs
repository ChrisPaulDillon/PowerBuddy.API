using System;
using System.Linq;
using PowerBuddy.App.Commands.Authentication;
using PowerBuddy.Data.Requests.Users;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Authentication
{
	public class RegisterUserCommandValidatorTests
	{
		private readonly Random _random;
		private readonly RegisterUserCommandValidator _validator;

		private readonly RegisterUserRequest _register;

		public RegisterUserCommandValidatorTests()
		{
			_random = new Random();
			_validator = new RegisterUserCommandValidator();
			_register = new RegisterUserRequest()
			{
				Email = _random.Next().ToString(),
				UserName = _random.Next().ToString(),
				Password = _random.Next().ToString()
			};
		}

		[Fact]
		public void CreateNew_ValidParameters_Passes()
		{
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.False(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_EmailIsNull_ReturnsValidationErrors()
		{
			_register.Email = null;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_EmailIsEmpty_ReturnsValidationErrors()
		{
			_register.Email = string.Empty;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PasswordIsNull_ReturnsValidationErrors()
		{
			_register.Password = null;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_PasswordIsEmpty_ReturnsValidationErrors()
		{
			_register.Password = string.Empty;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_UserNameIsNull_ReturnsValidationErrors()
		{
			_register.UserName = null;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}

		[Fact]
		public void CreateNew_UserNameIsEmpty_ReturnsValidationErrors()
		{
			_register.UserName = string.Empty;
			var result = _validator.Validate(new RegisterUserCommand(_register));
			Assert.True(result.Errors.Any());
		}
	}
}