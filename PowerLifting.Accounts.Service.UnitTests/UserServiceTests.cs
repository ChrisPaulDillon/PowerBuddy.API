using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Builders.Account;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Persistence;
using Xunit;

namespace PowerLifting.Accounts.Service.UnitTests
{
    public class UserServiceUnitTests
    {
        private readonly PowerLiftingContext _context;
        private readonly Random _random;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserServiceUnitTests()
        {
            _random = new Random();
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerLifting.Data")).CreateMapper();

            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: _random.Next().ToString())
                .Options;

            _context = new PowerLiftingContext(options);
        }

        //#region BanUser

        //[Fact]
        //public async Task BanUser_NoUserFound_ThrowsUserNotFoundException()
        //{
        //    // Arrange
        //    var adminUser = new UserBuilder().WithRights(1).Build();

        //    _context.User.Add(adminUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.BanUser("teststs", "test"));
        //}

        //[Fact]
        //public async Task BanUser_ModeratorNotFound_ThrowsUserNotFoundException()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().Build();

        //    _context.User.Add(normalUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.BanUser(normalUser.Id, "test"));
        //}


        //[Fact]
        //public async Task BanUser_UserIsBanned_ReturnsTrue()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().Build();
        //    var adminUser = new UserBuilder().WithRights(1).Build();

        //    _context.User.Add(normalUser);
        //    _context.User.Add(adminUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    var result = await _userService.BanUser(normalUser.Id, adminUser.Id);

        //    // Assert
        //    Assert.True(result);
        //}

        //#endregion

        //#region GetPublicUserProfileById

        //[Fact]
        //public async Task GetPublicUserProfileById_NoUserFound_ThrowsUserNotFoundException()
        //{
        //    await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetPublicUserProfileById("teststs"));
        //}

        //[Fact]
        //public async Task GetPublicUserProfileById_UserFound_ReturnsPublicUserDTO()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().Build();

        //    _context.User.Add(normalUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    var result = await _userService.GetPublicUserProfileById(normalUser.Id);

        //    // Assert
        //    Assert.IsType<PublicUserDTO>(result);
        //    Assert.NotNull(result);
        //}

        //#endregion

        //#region GetPublicUserProfileByUserName

        //[Fact]
        //public async Task GetPublicUserProfileByUserName_NoUserFound_ThrowsUserNotFoundException()
        //{
        //    await Assert.ThrowsAsync<UserNotFoundException>(async () => await _userService.GetPublicUserProfileByUserName("teststs"));
        //}

        //[Fact]
        //public async Task GetPublicUserProfileByUserName_UserFound_ReturnsPublicUserDTO()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().WithNormalizedUserName("TEST").WithUserName("TeSt").Build();

        //    _context.User.Add(normalUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    var result = await _userService.GetPublicUserProfileByUserName(normalUser.UserName);

        //    // Assert
        //    Assert.IsType<PublicUserDTO>(result);
        //    Assert.NotNull(result);
        //}

        //#endregion

        //#region RegisterUser

        //[Fact]
        //public async Task RegisterUser_InvalidEmail_ThrowsUserValidationException()
        //{
        //    await Assert.ThrowsAsync<UserValidationException>(async () => await _userService.RegisterUser(new RegisterUserDTO()));
        //}

        //[Fact]
        //public async Task RegisterUser_InvalidUserId_ThrowsUserValidationException()
        //{
        //    await Assert.ThrowsAsync<UserValidationException>(async () => await _userService.RegisterUser(new RegisterUserDTO() { Email = "test@test.com" }));
        //}

        //[Fact]
        //public async Task RegisterUser_InvalidPassword_ThrowsUserValidationException()
        //{
        //    await Assert.ThrowsAsync<UserValidationException>(async () => await _userService.RegisterUser(new RegisterUserDTO() { Email = "test@test.com", UserName = "test" }));
        //}

        //[Fact]
        //public async Task RegisterUser_EmailInUse_ThrowsEmailOrUserNameInUserException()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().WithEmail("test@test.com").WithNormalizedEmail("TEST@TEST.COM").Build();
        //    var userDTO = new RegisterUserDTO() { UserName = "teststs", Email = normalUser.Email, Password = "tetststs" };

        //    _context.User.Add(normalUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    // Assert
        //    await Assert.ThrowsAsync<EmailOrUserNameInUseException>(async () => await _userService.RegisterUser(userDTO));
        //}

        //[Fact]
        //public async Task RegisterUser_UserNameInUse_ThrowsEmailOrUserNameInUserException()
        //{
        //    // Arrange
        //    var normalUser = new UserBuilder().WithUserName("test").WithNormalizedUserName("TEST").Build();
        //    var userDTO = new RegisterUserDTO() { UserName = normalUser.UserName, Email = "test12121@tetete.com", Password = "teststst" };

        //    _context.User.Add(normalUser);
        //    await _context.SaveChangesAsync();

        //    // Act
        //    // Assert
        //    await Assert.ThrowsAsync<EmailOrUserNameInUseException>(async () => await _userService.RegisterUser(userDTO));
        //}

        //#endregion
    }
}
