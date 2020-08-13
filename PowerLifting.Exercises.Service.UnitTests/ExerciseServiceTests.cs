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
using PowerLifting.Data.Exceptions.Exercises;
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
            var exercise2 = new ExerciseBuilder().WithIsApproved(false).Build();
            _context.Exercise.Add(exercise);
            _context.Exercise.Add(exercise2);
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

        [Fact]
        public async Task GetExerciseById_ExerciseNotFound_ThrowsExerciseNotFoundException()
        {
            await Assert.ThrowsAsync<ExerciseNotFoundException>(async () => await _exerciseService.GetExerciseById(1));
        }

        [Fact]
        public async Task GetExerciseById_ExerciseIsFound_ReturnsExercise()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.GetExerciseById(exercise.ExerciseId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Exercise>(result);
        }

        [Fact]
        public async Task CreateExercise_ExerciseNameAlreadyExists_ThrowsExerciseNameAlreadyExistsException()
        {
            // Arrange
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            // Assert
            await Assert.ThrowsAsync<ExerciseAlreadyExistsException>(async () => await _exerciseService.CreateExercise(new CExerciseDTO() { ExerciseName = exercise.ExerciseName }));
        }

        [Fact]
        public async Task CreateExercise_ExerciseIsCreated_ReturnsExercise()
        {
            // Arrange
            var exercise = new CExerciseDTO() { ExerciseName = "test"};

            // Act
            var result = await _exerciseService.CreateExercise(exercise);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ExerciseDTO>(result);
        }

        [Fact]
        public async Task UpdateExercise_ExerciseDoesNotExist_ThrowsExerciseNotFoundException()
        {
            await Assert.ThrowsAsync<ExerciseNotFoundException>(async () => await _exerciseService.UpdateExercise(new ExerciseDTO() { ExerciseName = "test" }));
        }

        [Fact]
        public async Task UpdateExercise_ExerciseIsUpdated_ReturnsTrue()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = new ExerciseDTO() { ExerciseId = exercise.ExerciseId, ExerciseName = exercise.ExerciseName, ExerciseTypeId = 1};

            // Act
            var result = await _exerciseService.UpdateExercise(exerciseDTO);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteExercise_ExerciseDoesNotExist_ThrowsExerciseNotFoundException()
        {
            await Assert.ThrowsAsync<ExerciseNotFoundException>(async () => await _exerciseService.DeleteExercise(1));
        }

        [Fact]
        public async Task DeleteExercise_ExerciseIsUpdated_ReturnsTrue()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var exercise = new ExerciseBuilder().WithIsApproved(true).Build();
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();

            // Act
            var result = await _exerciseService.DeleteExercise(exercise.ExerciseId);

            // Assert
            Assert.True(result);
        }
    }
}
