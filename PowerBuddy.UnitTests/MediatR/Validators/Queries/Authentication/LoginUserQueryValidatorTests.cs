using System;
using System.Linq;
using PowerBuddy.App.Queries.Authentication;
using PowerBuddy.App.Queries.Authentication.Models;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Authentication
{
    public class LoginUserQueryValidatorTests
    {
        private readonly Random _random;
        private readonly LoginUserQueryValidator _validator;

        private readonly LoginRequestModel _login;

        public LoginUserQueryValidatorTests()
        {
            _random = new Random();
            _validator = new LoginUserQueryValidator();
            _login = new LoginRequestModel()
            {
                Email = _random.Next().ToString(),
                UserName = _random.Next().ToString(),
                Password = _random.Next().ToString()
            };
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_PasswordIsNull_ReturnsValidationErrors()
        {
            _login.Password = null;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_PasswordIsEmpty_ReturnsValidationErrors()
        {
            _login.Password = string.Empty;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_EmailIsNull_ReturnsValidationErrors()
        {
            _login.Email = null;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_EmailIsEmpty_ReturnsValidationErrors()
        {
            _login.Email = string.Empty;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsNull_ReturnsValidationErrors()
        {
            _login.UserName = null;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsEmpty_ReturnsValidationErrors()
        {
            _login.UserName = string.Empty;
            var result = _validator.Validate(new LoginUserQuery(_login));
            Assert.True(result.Errors.Any());
        }
    }
}