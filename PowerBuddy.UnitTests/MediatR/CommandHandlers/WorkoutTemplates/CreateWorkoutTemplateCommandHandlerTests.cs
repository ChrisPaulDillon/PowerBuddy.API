using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.MediatR.Commands.Workouts;
using PowerBuddy.MediatR.Commands.WorkoutTemplates;
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
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerBuddy.Data")).CreateMapper();
            _context = new PowerLiftingContext(options);
            _handler = new CreateWorkoutTemplateCommandHandler(_context, _mapper);

            _random = new Random();
        }

        [Fact]
        public async Task Handle_WorkoutTemplateIsCreated_ReturnsWorkoutTemplate()
        {
            // Arrange
            var templateWorkout = new WorkoutTemplateDTOBuilder().Build();

            var command = new CreateWorkoutTemplateCommand(templateWorkout, _random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsType<WorkoutTemplate>(result);
            Assert.Equal(templateWorkout.UserId, result.UserId);
            Assert.Equal(templateWorkout.DateCreated, result.DateCreated);
            Assert.Equal(templateWorkout.WorkoutName, result.WorkoutName);
            Assert.Equal(templateWorkout.WorkoutTemplateId, result.WorkoutTemplateId);
            Assert.NotNull(result.WorkoutExercises);
        }
    }
}
