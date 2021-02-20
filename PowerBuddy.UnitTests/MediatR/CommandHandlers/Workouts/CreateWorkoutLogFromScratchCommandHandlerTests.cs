using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PowerBuddy.App.Commands.Workouts;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.UnitTests.TestUtils;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.CommandHandlers.Workouts
{
    public class CreateWorkoutLogFromScratchCommandHandlerTests
    {
        private readonly CreateWorkoutLogFromScratchCommandHandler _handler;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        private readonly Random _random;
        private readonly WorkoutLogInputScratchDto _input;

        private readonly string _userId;

        public CreateWorkoutLogFromScratchCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps(TestConstants.MAPPER_ASSEMBLY)).CreateMapper();
            _context = new PowerLiftingContext(options);

            _handler = new CreateWorkoutLogFromScratchCommandHandler(_context, _mapper);

            _random = new Random();

            _userId = _random.Next().ToString();

            _input = new WorkoutLogInputScratchDto()
            {
                CustomName = _random.Next().ToString(),
                StartDate = new DateTime(2020, 3, 20),
                NoOfWeeks = 10,
                UserId = _userId
            };
        }

        [Fact]
        public async Task Handle_UserNotFound_ReturnsWorkoutDayNotFound()
        {
            // Arrange
            var command = new CreateWorkoutLogFromScratchCommand(_input, _random.Next().ToString());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsType<UserNotFound>(result.Value);
        }

        [Fact]
        public async Task Handle_StartDateIsFriday_ReturnsCreatedLog()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            var closestMonday = new DateTime(2020, 3, 16);
            var command = new CreateWorkoutLogFromScratchCommand(_input, _userId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);
            var workoutLog = await _context.WorkoutLog.AsNoTracking().Include(x => x.WorkoutDays.OrderBy(x => x.WeekNo)).FirstOrDefaultAsync();

            var workoutDays = workoutLog.WorkoutDays.OrderBy(x => x.Date).Take(7).ToList();

            // Assert
            var isCreated = result.AsT0;
            Assert.True(isCreated);
            Assert.Equal(_input.UserId, workoutLog.UserId);
            Assert.Equal(_input.CustomName, workoutLog.CustomName);
            Assert.Equal(70, workoutLog.WorkoutDays.Count());

            Assert.Equal(1, workoutDays[0].WeekNo);
            Assert.Equal(1, workoutDays[1].WeekNo);
            Assert.Equal(1, workoutDays[2].WeekNo);
            Assert.Equal(1, workoutDays[3].WeekNo);
            Assert.Equal(1, workoutDays[4].WeekNo);
            Assert.Equal(1, workoutDays[5].WeekNo);
            Assert.Equal(1, workoutDays[6].WeekNo);

            Assert.Equal(closestMonday, workoutDays[0].Date);
            Assert.Equal(closestMonday.AddDays(1), workoutDays[1].Date);
            Assert.Equal(closestMonday.AddDays(2), workoutDays[2].Date);
            Assert.Equal(closestMonday.AddDays(3), workoutDays[3].Date);
            Assert.Equal(closestMonday.AddDays(4), workoutDays[4].Date);
            Assert.Equal(closestMonday.AddDays(5), workoutDays[5].Date);
            Assert.Equal(closestMonday.AddDays(6), workoutDays[6].Date);
        }

        [Fact]
        public async Task Handle_StartDateIsSunday_ReturnsCreatedLog()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _input.StartDate = new DateTime(2020, 3, 22);

            var closestMonday = new DateTime(2020, 3, 16);
            var command = new CreateWorkoutLogFromScratchCommand(_input, _userId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);
            var workoutLog = await _context.WorkoutLog.AsNoTracking().Include(x => x.WorkoutDays.OrderBy(x => x.WeekNo)).FirstOrDefaultAsync();

            var workoutDays = workoutLog.WorkoutDays.OrderBy(x => x.Date).Take(7).ToList();

            // Assert
            var isCreated = result.AsT0;
            Assert.True(isCreated);
            Assert.Equal(_input.UserId, workoutLog.UserId);
            Assert.Equal(_input.CustomName, workoutLog.CustomName);
            Assert.Equal(70, workoutLog.WorkoutDays.Count());

            Assert.Equal(1, workoutDays[0].WeekNo);
            Assert.Equal(1, workoutDays[1].WeekNo);
            Assert.Equal(1, workoutDays[2].WeekNo);
            Assert.Equal(1, workoutDays[3].WeekNo);
            Assert.Equal(1, workoutDays[4].WeekNo);
            Assert.Equal(1, workoutDays[5].WeekNo);
            Assert.Equal(1, workoutDays[6].WeekNo);

            Assert.Equal(closestMonday, workoutDays[0].Date);
            Assert.Equal(closestMonday.AddDays(1), workoutDays[1].Date);
            Assert.Equal(closestMonday.AddDays(2), workoutDays[2].Date);
            Assert.Equal(closestMonday.AddDays(3), workoutDays[3].Date);
            Assert.Equal(closestMonday.AddDays(4), workoutDays[4].Date);
            Assert.Equal(closestMonday.AddDays(5), workoutDays[5].Date);
            Assert.Equal(closestMonday.AddDays(6), workoutDays[6].Date);
        }
    }
}
