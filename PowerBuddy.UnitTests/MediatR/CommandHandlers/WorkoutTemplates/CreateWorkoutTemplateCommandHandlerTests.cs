using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.WorkoutTemplates;
using PowerBuddy.Data.Builders.Dtos.Workouts;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.UnitTests.TestUtils;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.CommandHandlers.WorkoutTemplates
{
    public class CreateWorkoutTemplateCommandHandlerTests
    {
        private readonly CreateWorkoutTemplateCommandHandler _handler;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        private readonly Random _random;

        public CreateWorkoutTemplateCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps(TestConstants.MAPPER_ASSEMBLY)).CreateMapper();
            _context = new PowerLiftingContext(options);
            _handler = new CreateWorkoutTemplateCommandHandler(_context, _mapper);

            _random = new Random();
        }

        [Fact]
        public async Task Handle_WorkoutNameExists_ReturnsWorkoutNameAlreadyExists()
        {
            // Arrange
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new CreateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsType<WorkoutNameAlreadyExists>(result.AsT1);
        }

        [Fact]
        public async Task Handle_WorkoutNameExistsDifferentCasing_ReturnsWorkoutNameAlreadyExists()
        {
            // Arrange
            var userId = _random.Next().ToString();

            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("TeSt").WithUserId(userId).Build();

            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new CreateWorkoutTemplateCommand(workoutTemplateDto, userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsType<WorkoutNameAlreadyExists>(result.AsT1);
        }

        [Fact]
        public async Task Handle_WorkoutNameExistsDifferentUser_ReturnsWorkoutTemplate()
        {
            // Arrange
            var workoutTemplateDto = new WorkoutTemplateDtoBuilder().WithTemplateName("Test").Build();

            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new CreateWorkoutTemplateCommand(workoutTemplateDto, _random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            var workoutTemplateResult = result.AsT0;

            Assert.IsType<WorkoutTemplate>(workoutTemplateResult);
            Assert.Equal(workoutTemplateDto.UserId, workoutTemplateResult.UserId);
            Assert.Equal(workoutTemplateDto.DateCreated, workoutTemplateResult.DateCreated);
            Assert.Equal(workoutTemplateDto.WorkoutName, workoutTemplateResult.WorkoutName);
            Assert.Equal(workoutTemplateDto.WorkoutTemplateId, workoutTemplateResult.WorkoutTemplateId);
            Assert.NotNull(workoutTemplateResult.WorkoutExercises);
        }

        [Fact]
        public async Task Handle_WorkoutTemplateIsCreated_ReturnsWorkoutTemplate()
        {
            // Arrange
            var templateWorkout = new WorkoutTemplateDtoBuilder().Build();

            var command = new CreateWorkoutTemplateCommand(templateWorkout, _random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            var workoutTemplateResult = result.AsT0;

            Assert.IsType<WorkoutTemplate>(workoutTemplateResult);
            Assert.Equal(templateWorkout.UserId, workoutTemplateResult.UserId);
            Assert.Equal(templateWorkout.DateCreated, workoutTemplateResult.DateCreated);
            Assert.Equal(templateWorkout.WorkoutName, workoutTemplateResult.WorkoutName);
            Assert.Equal(templateWorkout.WorkoutTemplateId, workoutTemplateResult.WorkoutTemplateId);
            Assert.NotNull(workoutTemplateResult.WorkoutExercises);
        }
    }
}
