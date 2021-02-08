using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PowerBuddy.App.Commands.WorkoutDays;
using PowerBuddy.App.Services.LiftingStats;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Builders.DTOs.Workouts;
using PowerBuddy.Data.Builders.Entities.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Models.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.CommandHandlers.WorkoutDays
{
	public class CompleteWorkoutCommandHandlerTests
	{
		private readonly CompleteWorkoutCommandHandler _handler;
		private readonly PowerLiftingContext _context;
		private readonly IMapper _mapper;
		private readonly Mock<IWorkoutService> _workoutService;
		private readonly Mock<ILiftingStatService> _liftingStatService;
		private readonly Mock<IEntityFactory> _entityFactory;

		private readonly Random _random;

		private IDictionary<int, LiftingStatAudit> _personalBests;

		public CompleteWorkoutCommandHandlerTests()
		{
			var options = new DbContextOptionsBuilder<PowerLiftingContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
			_mapper = new MapperConfiguration(cfg => cfg.AddMaps("PowerBuddy.Data")).CreateMapper();
			_context = new PowerLiftingContext(options);

			_workoutService = new Mock<IWorkoutService>(MockBehavior.Strict);
			_liftingStatService = new Mock<ILiftingStatService>(MockBehavior.Strict);
			_entityFactory = new Mock<IEntityFactory>(MockBehavior.Strict);

			_handler = new CompleteWorkoutCommandHandler(_context, _mapper, _workoutService.Object, _liftingStatService.Object, _entityFactory.Object);

			_random = new Random();

			_personalBests = new Dictionary<int, LiftingStatAudit>();
		}

		[Fact]
		public async Task Handle_WorkoutDayNotFound_ReturnsWorkoutDayNotFound()
		{
			// Arrange
			var workoutDay = new WorkoutDayDtoBuilder().Build();
			var command = new CompleteWorkoutCommand(workoutDay, _random.Next().ToString());

			// Act
			var result = await _handler.Handle(command, CancellationToken.None);

			// Assert
			Assert.IsType<WorkoutDayNotFound>(result.Value);
		}

		[Fact]
		public async Task Handle_PersonalBestFoundAndIsLower_NewPersonalBestIsReturned()
		{
			// Arrange
			var workoutDayId = _random.Next();
			var userId = _random.Next().ToString();
			var workoutExerciseId = _random.Next();
			var workoutSetId = _random.Next();

			var workoutSetDto = new WorkoutSetDtoBuilder().WithWorkoutSetId(workoutSetId).Build();
			var workoutExerciseDto = new WorkoutExerciseDtoBuilder().WithWorkoutExerciseId(workoutExerciseId).WithWorkoutSets(new List<WorkoutSetDto>() {workoutSetDto}).Build();

			var workoutDayDto = new WorkoutDayDtoBuilder()
				.WithUserId(userId)
				.WithWorkoutDayId(workoutDayId)
				.WithWorkoutExercises(new List<WorkoutExerciseDto>() { workoutExerciseDto })
				.Build();

			var personalBest = new LiftingStatAuditBuilder().WithWeight(5).Build();
			var hitPersonalBest = new LiftingStatAuditBuilder().WithWeight(500).Build();

			_personalBests.Add(1, personalBest);

			var workoutSet = new WorkoutSetBuilder().WithWorkoutSetId(workoutSetId).Build();
			var workoutExercise = new WorkoutExerciseBuilder().WithWorkoutExerciseId(workoutExerciseId).WithWorkoutSets(new List<WorkoutSet>() { workoutSet }).Build();

			var workoutDay = new WorkoutDayBuilder()
				.WithUserId(userId)
				.WithWorkoutDayId(workoutDayId)
				.WithWorkoutExercises(new List<WorkoutExercise>() { workoutExercise })
				.Build();

			await _context.WorkoutDay.AddAsync(workoutDay);
			await _context.SaveChangesAsync();

			_context.Entry(workoutSet).State = EntityState.Detached;

			_workoutService.Setup(x => x.GetHighestWeightRepSchemeForEachRepFromCollection(It.IsAny<IEnumerable<WorkoutSetDto>>())).Returns(workoutExerciseDto.WorkoutSets);
			_liftingStatService.Setup(x => x.GetPersonalBestsForRepRangeAndExercise(It.IsAny<IList<int>>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_personalBests);
			_entityFactory.Setup(x => x.CreateLiftingStatAudit(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(hitPersonalBest);

			var command = new CompleteWorkoutCommand(workoutDayDto, userId);

			// Act
			var result = await _handler.Handle(command, CancellationToken.None);

			// Assert
			var personalBestList = (List<LiftingStatAuditDto>)result.Value;
			Assert.IsType<List<LiftingStatAuditDto>>(personalBestList);
			Assert.NotEmpty(personalBestList);

			var personalBestResult = await _context.LiftingStatAudit.AsNoTracking().FirstOrDefaultAsync();
			var workoutSetResult = await _context.WorkoutSet.AsNoTracking().FirstOrDefaultAsync();

			Assert.Equal(personalBestResult.LiftingStatAuditId, workoutSetResult.LiftingStatAuditId);
			Assert.Equal(workoutSetResult.WorkoutSetId, personalBestResult.WorkoutSetId);
		}
	}
}
