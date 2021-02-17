using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.Data.Builders.Entities.Account;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.UnitTests.TestUtils;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.QueryHandlers.WorkoutDays
{
	public class GetWorkoutDayByIdQueryHandlerTests
	{
		private readonly GetWorkoutDayByIdQueryHandler _handler;
		private readonly PowerLiftingContext _context;
		private readonly IMapper _mapper;

		private readonly Random _random;

		public GetWorkoutDayByIdQueryHandlerTests()
		{
			var options = new DbContextOptionsBuilder<PowerLiftingContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
			_mapper = new MapperConfiguration(cfg => cfg.AddMaps(TestConstants.MAPPER_ASSEMBLY)).CreateMapper();
			_context = new PowerLiftingContext(options);
			_handler = new GetWorkoutDayByIdQueryHandler(_context, _mapper);
			_random = new Random();
		}

		[Fact]
		public async Task Handle_NoWorkoutFound_ReturnsWorkoutDayNotFound()
		{
			// Arrange
			var query = new GetWorkoutDayByIdQuery(_random.Next());

			// Act
			// Assert
			var result = await _handler.Handle(query, CancellationToken.None);

			Assert.IsType<WorkoutDayNotFound>(result.Value);
		}

		[Fact]
		public async Task Handle_WorkoutFound_ReturnsWorkoutDayDto()
		{
			// Arrange
			var workoutDayId = _random.Next();
			var workoutLogId = _random.Next();
			var userId = _random.Next().ToString();

			var workoutDay = new WorkoutDayBuilder().WithWorkoutDayId(workoutDayId).WithWorkoutLogId(workoutLogId).WithUserId(userId).Build();
			var workoutLog = new WorkoutLogBuilder().WithWorkoutLogId(workoutLogId).WithUserId(userId).Build();
			var user = new UserBuilder().WithUserId(userId).Build();

			await _context.User.AddAsync(user);
			await _context.WorkoutLog.AddAsync(workoutLog);
			await _context.WorkoutDay.AddAsync(workoutDay);
			await _context.SaveChangesAsync();

			var command = new GetWorkoutDayByIdQuery(workoutDayId);

			// Act
			// Assert
			var result = await _handler.Handle(command, CancellationToken.None);

			Assert.IsType<WorkoutDayDto>(result);
			var workoutDayDto = (WorkoutDayDto)result.Value;
			Assert.Equal(workoutDay.WorkoutDayId, workoutDayDto.WorkoutDayId);
			Assert.Equal(workoutDay.UserId, workoutDayDto.UserId);
			Assert.Equal(workoutDay.Comment, workoutDayDto.Comment);
			Assert.Equal(workoutDay.Date, workoutDayDto.Date);
			Assert.Equal(workoutDay.WeekNo, workoutDayDto.WeekNo);
			Assert.Equal(workoutDay.Completed, workoutDayDto.Completed);
			Assert.Equal(user.UserName, workoutDayDto.UserName);
		}
	}
}