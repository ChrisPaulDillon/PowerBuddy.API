using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.Dtos.Workouts;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.CommandHandlers.WorkoutTemplates
{
    public class UpdateWorkoutTemplateCommandHandlerTests
    {
        private readonly UpdateWorkoutTemplateCommandHandler _handler;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        private readonly Random _random;

        public UpdateWorkoutTemplateCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerBuddy.Data")).CreateMapper();
            _context = new PowerLiftingContext(options);
            _handler = new UpdateWorkoutTemplateCommandHandler(_context, _mapper);
            _random = new Random();
        }

        [Fact]
        public async Task Handle_WorkoutDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            var command = new UpdateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_WorkoutNameExistsForUser_ReturnsFalse()
        {
            // Arrange
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new UpdateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_WorkoutNameExistsForUserDifferentCasing_ReturnsFalse()
        {
            // Arrange
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("TEsT").WithUserId(userId).Build();

            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new UpdateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task Handle_WorkoutNameExistsOnSameWorkout_ReturnsTrue()
        {
            // Arrange
            var workoutTemplateId = _random.Next();
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder()
                .WithTemplateName("TEsT")
                .WithUserId(userId)
                .WithWorkoutTemplateId(workoutTemplateId).Build();

            var workoutTemplate = new WorkoutTemplateBuilder()
                .WithTemplateName("Test")
                .WithUserId(userId)
                .WithWorkoutTemplateId(workoutTemplateId)
                .Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            _context.Entry(workoutTemplate).State = EntityState.Detached;

            var command = new UpdateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task Handle_WorkoutTemplateIsUpdated_ReturnsTrue()
        {
            // Arrange
            var workoutTemplateId = _random.Next();
            var userId = _random.Next().ToString();
            var updatedName = "Updated name lmfao";

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder()
                .WithTemplateName(updatedName)
                .WithUserId(userId)
                .WithWorkoutTemplateId(workoutTemplateId)
                .Build();

            var workoutTemplate = new WorkoutTemplateBuilder()
                .WithTemplateName("Test")
                .WithUserId(userId)
                .WithWorkoutTemplateId(workoutTemplateId)
                .Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            _context.Entry(workoutTemplate).State = EntityState.Detached;

            var command = new UpdateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            var workoutTemplateResult = await _context.WorkoutTemplate.AsNoTracking().FirstOrDefaultAsync();

            Assert.True(result);
            Assert.Equal(updatedName, workoutTemplateResult.WorkoutName);
        }
    }
}
