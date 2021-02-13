using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.CommandHandlers.WorkoutTemplates
{
    public class DeleteWorkoutTemplateCommandHandlerTests
    {
        private readonly DeleteWorkoutTemplateCommandHandler _handler;
        private readonly PowerLiftingContext _context;

        private readonly Random _random;

        public DeleteWorkoutTemplateCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new PowerLiftingContext(options);
            _handler = new DeleteWorkoutTemplateCommandHandler(_context);
            _random = new Random();
        }

        [Fact]
        public async Task Handle_NoWorkoutTemplateFound_ReturnsFalse()
        {
            // Arrange
            var command = new DeleteWorkoutTemplateCommand(_random.Next(), _random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_WorkoutExistsWrongUser_ReturnsFalse()
        {
            // Arrange
            var workoutTemplateId = _random.Next();

            var workoutTemplate = new WorkoutTemplateBuilder().WithWorkoutTemplateId(workoutTemplateId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new DeleteWorkoutTemplateCommand(workoutTemplateId, _random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_WorkoutExistsIsDeleted_ReturnsTrue()
        {
            // Arrange
            var workoutTemplateId = _random.Next();
            var userId = _random.Next().ToString();

            var workoutTemplate = new WorkoutTemplateBuilder().WithWorkoutTemplateId(workoutTemplateId).WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new DeleteWorkoutTemplateCommand(workoutTemplateId, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result);
        }
    }
}
