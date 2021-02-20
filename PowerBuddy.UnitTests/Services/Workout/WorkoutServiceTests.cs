using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.UnitTests.TestUtils;
using Xunit;

namespace PowerBuddy.UnitTests.Services.Workout
{
    public class WorkoutServiceTests
    {
        private readonly PowerLiftingContext _dbContext;
        private readonly WorkoutService _workoutService;
        private readonly IMapper _mapper;
        private readonly Random _random;

        private readonly IEnumerable<TemplateExerciseDto> _templateExercises;
        private readonly IEnumerable<TemplateWeightInputDto> _weightInputs;

        public WorkoutServiceTests()
        {
            var options = new DbContextOptionsBuilder<PowerLiftingContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new PowerLiftingContext(options);
            _mapper = new MapperConfiguration(cfg => cfg.AddMaps(TestConstants.MAPPER_ASSEMBLY)).CreateMapper();

            _workoutService = new WorkoutService(_dbContext, _mapper, null);
            _random = new Random();

            var weightInput1 = new TemplateWeightInputDto()
            {
                ExerciseId = 1, 
                ExerciseName = "Back Squat",
                Weight = 100
            };

            var weightInput2 = new TemplateWeightInputDto()
            {
                ExerciseId = 2,
                ExerciseName = "Deadlift",
                Weight = 100
            };

            _weightInputs = new List<TemplateWeightInputDto>() { weightInput1, weightInput2};

            var templateExercise1 = new TemplateExerciseDto()
            {
                ExerciseId = 1,
                ExerciseName = "Back Squat",
                TemplateRepSchemes = new List<TemplateRepSchemeDto>()
                {
                    new TemplateRepSchemeDto() { NoOfReps = 5, Percentage = 10 },
                    new TemplateRepSchemeDto() { NoOfReps = 10, Percentage = 25 }
                }
            };

            var templateExercise2 = new TemplateExerciseDto()
            {
                ExerciseId = 2,
                ExerciseName = "Deadlift",
                TemplateRepSchemes = new List<TemplateRepSchemeDto>()
                {
                    new TemplateRepSchemeDto() { NoOfReps = 5, Percentage = 10 },
                    new TemplateRepSchemeDto() { NoOfReps = 10, Percentage = 25 }
                }
            };

            _templateExercises = new List<TemplateExerciseDto>() { templateExercise1, templateExercise2};
        }

        #region DoesWorkoutLogExistOnDates

        [Fact]
        public async Task DoesWorkoutLogExistOnDates_StartDateOverlaps_ReturnsString()
        {
            // Arrange
            var startDate = new DateTime(2020, 3, 17);
            var endDate = new DateTime(2020, 3, 28);

            var programStartDate = new DateTime(2020, 3, 15);

            var workoutLogId = _random.Next();
            var userId = _random.Next().ToString();

            var workoutDay1 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate).Build();
            var workoutDay2 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(1)).Build();
            var workoutDay3 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(2)).Build();
            var workoutDay4 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(3)).Build();
            var workoutDay5 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(4)).Build();
            var workoutDay6 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(5)).Build();
            var workoutDay7 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(6)).Build();

            var workoutDays = new List<WorkoutDay>() { workoutDay1, workoutDay2, workoutDay3, workoutDay4, workoutDay5, workoutDay6, workoutDay7 };

            var workout = new WorkoutLogBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithWorkoutDays(workoutDays).WithCustomName("5/3/1").Build();

            await _dbContext.WorkoutLog.AddAsync(workout);
            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _workoutService.DoesWorkoutLogExistOnDates(startDate, endDate, userId);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task DoesWorkoutLogExistOnDates_EndDateOverlaps_ReturnsString()
        {
            // Arrange
            var startDate = new DateTime(2020, 3, 10);
            var endDate = new DateTime(2020, 3, 17);

            var programStartDate = new DateTime(2020, 3, 15);

            var workoutLogId = _random.Next();
            var userId = _random.Next().ToString();

            var workoutDay1 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate).Build();
            var workoutDay2 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(1)).Build();
            var workoutDay3 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(2)).Build();
            var workoutDay4 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(3)).Build();
            var workoutDay5 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(4)).Build();
            var workoutDay6 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(5)).Build();
            var workoutDay7 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(6)).Build();

            var workoutDays = new List<WorkoutDay>() {workoutDay1, workoutDay2, workoutDay3, workoutDay4, workoutDay5, workoutDay6, workoutDay7};

            var workout = new WorkoutLogBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithWorkoutDays(workoutDays).WithCustomName("5/3/1").Build();

            await _dbContext.WorkoutLog.AddAsync(workout);
            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _workoutService.DoesWorkoutLogExistOnDates(startDate, endDate, userId);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task DoesWorkoutLogExistOnDates_NoOverlap_ReturnsEmptyString()
        {
            // Arrange
            var startDate = new DateTime(2020, 4, 30);
            var endDate = new DateTime(2020, 6, 17);

            var programStartDate = new DateTime(2020, 3, 15);

            var workoutLogId = _random.Next();
            var userId = _random.Next().ToString();

            var workoutDay1 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate).Build();
            var workoutDay2 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(1)).Build();
            var workoutDay3 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(2)).Build();
            var workoutDay4 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(3)).Build();
            var workoutDay5 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(4)).Build();
            var workoutDay6 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(5)).Build();
            var workoutDay7 = new WorkoutDayBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithDate(programStartDate.AddDays(6)).Build();

            var workoutDays = new List<WorkoutDay>() { workoutDay1, workoutDay2, workoutDay3, workoutDay4, workoutDay5, workoutDay6, workoutDay7 };

            var workout = new WorkoutLogBuilder().WithUserId(userId).WithWorkoutLogId(workoutLogId).WithWorkoutDays(workoutDays).WithCustomName("5/3/1").Build();

            await _dbContext.WorkoutLog.AddAsync(workout);
            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _workoutService.DoesWorkoutLogExistOnDates(startDate, endDate, userId);

            // Assert
            Assert.Empty(result);
        }

        #endregion

        #region CreateWorkoutSetsForTemplateExercise

        [Fact]
        public void CreateWorkoutSetsForTemplateExercise_PercentageBased_ReturnsWorkoutSetsAndTonnage()
        {
            // Arrange
            var templateExercise = new TemplateExerciseDto()
            {
                ExerciseId = 1,
                ExerciseName = "Back Squat",
                TemplateRepSchemes = new List<TemplateRepSchemeDto>()
                {
                    new TemplateRepSchemeDto() {NoOfReps = 5, Percentage = 10},
                    new TemplateRepSchemeDto() {NoOfReps = 10, Percentage = 25}
                }
            };

            var weightInput = new TemplateWeightInputDto()
            {
                ExerciseId = 1,
                ExerciseName = "Back Squat",
                Weight = 100
            };

            decimal percentage1 = (decimal)10 / 100;
            var workoutSetWeight1 = percentage1 * 100;
            decimal percentage2 = (decimal)25 / 100;
            var workoutSetWeight2 = percentage2 * 100;

            var workoutSetTonnage1 = workoutSetWeight1 * 5;
            var workoutSetTonnage2 = workoutSetWeight2 * 10;

            decimal expectedTonnage = workoutSetTonnage1 + workoutSetTonnage2;

            //Act
            var result = _workoutService.CreateWorkoutSetsForTemplateExercise(templateExercise, weightInput, "PERCENTAGE", out var exerciseTonnage);

            // Assert
            var workoutSets = result.ToList();

            Assert.IsType<List<WorkoutSet>>(result);
            Assert.Equal(expectedTonnage, exerciseTonnage);
            Assert.Equal(workoutSetWeight1, workoutSets[0].WeightLifted);
            Assert.Equal(workoutSetWeight2, workoutSets[1].WeightLifted);
        }

        //[Fact]
        //public void CreateWorkoutSetsForTemplateExercise_IncrementalBased_ReturnsWorkoutSetsAndTonnage()
        //{
        //    // Arrange
        //    var templateExercise = new TemplateExerciseDto()
        //    {
        //        ExerciseId = 1,
        //        ExerciseName = "Back Squat",
        //        TemplateRepSchemes = new List<TemplateRepSchemeDto>()
        //        {
        //            new TemplateRepSchemeDto() {NoOfReps = 5, Percentage = 10},
        //            new TemplateRepSchemeDto() {NoOfReps = 10, Percentage = 25}
        //        }
        //    };

        //    var weightInput = new TemplateWeightInputDto()
        //    {
        //        ExerciseId = 1,
        //        ExerciseName = "Back Squat",
        //        Weight = 2.5M //Increment by 2.5
        //    };

        //    decimal percentage1 = (decimal)10 / 100;
        //    var workoutSetWeight1 = percentage1 * 100;
        //    decimal percentage2 = (decimal)25 / 100;
        //    var workoutSetWeight2 = percentage2 * 100;

        //    var workoutSetTonnage1 = workoutSetWeight1 * 5;
        //    var workoutSetTonnage2 = workoutSetWeight2 * 10;

        //    decimal expectedTonnage = workoutSetTonnage1 + workoutSetTonnage2;

        //    //Act
        //    var result = _workoutService.CreateWorkoutSetsForTemplateExercise(templateExercise, weightInput, "INCREMENTAL", out var exerciseTonnage);

        //    // Assert
        //    var workoutSets = result.ToList();

        //    Assert.IsType<List<WorkoutSet>>(result);
        //    Assert.Equal(expectedTonnage, exerciseTonnage);
        //    Assert.Equal(workoutSetWeight1, workoutSets[0].WeightLifted);
        //    Assert.Equal(workoutSetWeight2, workoutSets[1].WeightLifted);
        //}

        #endregion
    }
}

