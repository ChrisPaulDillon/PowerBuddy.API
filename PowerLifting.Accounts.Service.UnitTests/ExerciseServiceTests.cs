using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Builders.Account;
using PowerLifting.Data.Builders.Exercises;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Persistence;
using Xunit;

namespace PowerLifting.Accounts.Service.UnitTests
{
    public class AccountServiceUnitTests
    {
        private readonly PowerLiftingContext _context;
        private readonly UserService _userService;
        private readonly Random _random;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AccountServiceUnitTests()
        {
            _random = new Random();
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerLifting.Data")).CreateMapper();

            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: _random.Next().ToString())
                .Options;

            _context = new PowerLiftingContext(options);
            _userService = new UserService(_context, _mapper, _userManager, null);
        }

        #region BanUser

        [Fact]
        public async Task BanUser_NoUserFound_ThrowsUserNotFoundException()
        {
            // Arrange
            var adminUser = new UserBuilder().WithRights(1).Build();

            _context.User.Add(adminUser);
            await _context.SaveChangesAsync();

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.BanUser("teststs", "test"));
        }

        [Fact]
        public async Task BanUser_ModeratorNotFound_ThrowsUserNotFoundException()
        {
            // Arrange
            var normalUser = new UserBuilder().Build();

            _context.User.Add(normalUser);
            await _context.SaveChangesAsync();

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.BanUser(normalUser.Id, "test"));
        }


        [Fact]
        public async Task BanUser_UserIsBanned_ReturnsTrue()
        {
            // Arrange
            var normalUser = new UserBuilder().Build();
            var adminUser = new UserBuilder().WithRights(1).Build();

            _context.User.Add(normalUser);
            _context.User.Add(adminUser);
            await _context.SaveChangesAsync();

            // Act
            var result = await _userService.BanUser(normalUser.Id, adminUser.Id);

            // Assert
            Assert.True(result);
        }

        #endregion
    }
}
