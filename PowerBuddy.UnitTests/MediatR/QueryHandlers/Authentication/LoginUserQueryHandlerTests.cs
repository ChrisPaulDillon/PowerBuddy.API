using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using PowerBuddy.App.Queries.Authentication;
using PowerBuddy.App.Queries.Authentication.Models;
using PowerBuddy.App.Services.Authentication;
using PowerBuddy.Data.Builders.Entities.Account;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.UnitTests.TestUtils;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.QueryHandlers.Authentication
{
    public class LoginUserQueryHandlerTests
    {
        private readonly LoginUserQueryHandler _handler;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        private readonly Mock<SignInManager<User>> _signInManager;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Random _random;
        private readonly LoginRequestModel _loginModel;


        public LoginUserQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new PowerLiftingContext(options);
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps(TestConstants.MAPPER_ASSEMBLY)).CreateMapper();
            _tokenService = new Mock<ITokenService>(MockBehavior.Strict);

            _handler = new LoginUserQueryHandler(_context, _mapper, null, _tokenService.Object);
            _random = new Random();

            _loginModel = new LoginRequestModel()
            {
                UserName = _random.Next().ToString(),
                Email = _random.Next().ToString(),
                Password = _random.Next().ToString()
            };
        }

        [Fact]
        public async Task Handle_UserNotFound_ReturnsUserNotFound()
        {
            // Arrange
            var query = new LoginUserQuery(_loginModel);

            // Act
            // Assert
            var result = await _handler.Handle(query, CancellationToken.None);

            var userNotFound = (UserNotFound)result.Value;
            Assert.IsType<UserNotFound>(userNotFound);
        }

        [Fact]
        public async Task Handle_UserFoundEmailNotConfirmed_ReturnsEmailNotConfirmed()
        {
            // Arrange
            var userId = _random.Next().ToString();
            var email = _random.Next().ToString();
            var user = new UserBuilder().WithEmailConfirmed(false).WithUserId(userId).WithNormalizedEmail(email).Build();

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            _loginModel.Email = email;
            var query = new LoginUserQuery(_loginModel);

            // Act
            // Assert
            var result = await _handler.Handle(query, CancellationToken.None);

            var emailNotConfirmed = (EmailNotConfirmed)result.Value;
            Assert.IsType<EmailNotConfirmed>(emailNotConfirmed);
        }
    }
}
