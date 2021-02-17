using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.Data.Builders.Entities.Account;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.QueryHandlers.WorkoutDays
{
	public class GetAllPublicWorkoutDayIdsQueryHandlerTests
    {
        private readonly GetAllPublicWorkoutDayIdsQueryHandler _handler;
        private readonly PowerLiftingContext _context;

        private readonly Random _random;

        public GetAllPublicWorkoutDayIdsQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new PowerLiftingContext(options);
            _handler = new GetAllPublicWorkoutDayIdsQueryHandler(_context);
            _random = new Random();
        }

		[Fact]
		public async Task Handle_NoWorkoutIdsFound_ReturnsEmptyList()
		{
			// Arrange
			var query = new GetAllPublicWorkoutDayIdsQuery();

			// Act
			// Assert
			var result = await _handler.Handle(query, CancellationToken.None);

			var workoutIds = result.ToList();
			Assert.IsType<List<int>>(workoutIds);
			Assert.Empty(workoutIds);
		}

		[Fact]
		public async Task Handle_WorkoutIdsFound_ReturnsCollectionOfWorkoutIds()
		{
			// Arrange
			var userId = _random.Next().ToString();

			var user = new UserBuilder().WithUserId(userId).WithIsPublic(true).Build();
			var workoutDay = new WorkoutDayBuilder().WithUserId(userId).Build();

			await _context.User.AddAsync(user);
			await _context.WorkoutDay.AddAsync(workoutDay);
			await _context.SaveChangesAsync();

			var command = new GetAllPublicWorkoutDayIdsQuery();

			// Act
			// Assert
			var result = await _handler.Handle(command, CancellationToken.None);

			Assert.IsType<List<int>>(result.ToList());
			Assert.NotEmpty(result);
		}

		[Fact]
		public async Task Handle_WorkoutIdsFoundUserNotPublic_ReturnsEmptyCollection()
		{
			// Arrange
			var userId = _random.Next().ToString();

			var user = new UserBuilder().WithUserId(userId).WithIsPublic(false).Build();
			var workoutDay = new WorkoutDayBuilder().WithUserId(userId).Build();

			await _context.User.AddAsync(user);
			await _context.WorkoutDay.AddAsync(workoutDay);
			await _context.SaveChangesAsync();

			var command = new GetAllPublicWorkoutDayIdsQuery();

			// Act
			// Assert
			var result = await _handler.Handle(command, CancellationToken.None);

			Assert.IsType<List<int>>(result.ToList());
			Assert.Empty(result);
		}
	}
}