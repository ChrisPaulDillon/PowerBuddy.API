using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Builders.Exercises;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Persistence;
using Xunit;

namespace PowerLifting.Exercises.Service.UnitTests
{
    public class ExerciseServiceTests
    {
        private readonly PowerLiftingContext _context;
        private readonly ExerciseService _exerciseService;
        private readonly Random _random;
        private readonly IMapper _mapper;

        public ExerciseServiceTests()
        {
            _random = new Random();
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerLifting.Data")).CreateMapper();

            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(databaseName: _random.Next().ToString())
                .Options;

            _context = new PowerLiftingContext(options);
            _exerciseService = new ExerciseService(_context, _mapper);
        }

        [Fact]
        public async Task GetAllExercises_OnlyNonApprovedExercises_ReturnsEmptyCollection()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(false).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllExercises();

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
            Assert.IsType<List<ExerciseDTO>>(result);
        }

        [Fact]
        public async Task GetAllExercises_ApprovedExercisesAvailable_ReturnsCollection()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllExercises();

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.IsType<List<ExerciseDTO>>(result);
        }

        [Fact]
        public async Task GetAllUnapprovedExercises_OnlyApprovedExercises_ReturnsEmptyCollection()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllUnapprovedExercises();

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
            Assert.IsType<List<ExerciseDTO>>(result);
        }

        [Fact]
        public async Task GetAllUnapprovedExercises_UnapprovedExercisesAvailable_ReturnsCollection()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(false).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllUnapprovedExercises();

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.IsType<List<ExerciseDTO>>(result);
        }

        [Fact]
        public async Task GetAllExercisesBySport_OnlyExercisesWithNoSport_ReturnsEmptyCollection()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllExercisesBySport("Test");

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
            Assert.IsType<List<TopLevelExerciseDTO>>(result);
        }

        [Fact]
        public async Task GetAllExercisesBySport_ExerciseUnderSportIsAvailable_ReturnsCollection()
        {
            // Arrange
            var sport = "PowerLifting";
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            exercise.ExerciseSports = new List<ExerciseSport>() { new ExerciseSport() { ExerciseSportStr = sport } };
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetAllExercisesBySport(sport);

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.IsType<List<TopLevelExerciseDTO>>(result);
        }
    }
}
