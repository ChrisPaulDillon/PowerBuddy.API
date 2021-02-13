using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Queries.WorkoutTemplates;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.DTOs.WorkoutTemplates;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.QueryHandlers.WorkoutTemplates
{
    public class GetAllUserWorkoutTemplatesCommandHandlerTests
    {
        private readonly GetAllUserWorkoutTemplatesQueryHandler _handler;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        private readonly Random _random;

        public GetAllUserWorkoutTemplatesCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerBuddy.Data")).CreateMapper();
            _context = new PowerLiftingContext(options);
            _handler = new GetAllUserWorkoutTemplatesQueryHandler(_context, _mapper);
            _random = new Random();
        }

        [Fact]
        public async Task Handle_NoWorkoutTemplatesFound_ReturnsEmptyList()
        {
            // Arrange
            var command = new GetAllUserWorkoutTemplatesQuery(_random.Next().ToString());

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            var templates = result.ToList();
            Assert.IsType<List<WorkoutTemplateDto>>(templates);
            Assert.Empty(templates);
        }

        [Fact]
        public async Task Handle_WorkoutTemplateExists_ReturnsCollectionOfWorkoutTemplates()
        {
            // Arrange
            var userId = _random.Next().ToString();
            var workoutTemplate = new WorkoutTemplateBuilder().WithTemplateName("Test").WithUserId(userId).Build();

            await _context.WorkoutTemplate.AddAsync(workoutTemplate);
            await _context.SaveChangesAsync();

            var command = new GetAllUserWorkoutTemplatesQuery(userId);

            // Act
            // Assert
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsType<List<WorkoutTemplateDto>>(result.ToList());
            Assert.NotEmpty(result);
        }
    }
}