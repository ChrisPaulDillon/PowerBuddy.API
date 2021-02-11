using System;
using System.Linq;
using PowerBuddy.App.Commands.Workouts;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Workouts
{
    public class CreateWorkoutLogFromScratchCommandValidatorTests
    {
        private readonly Random _random;
        private readonly CreateWorkoutLogFromScratchCommandValidator _validator;

        private readonly WorkoutLogInputScratchDto _workoutLogInput;

        public CreateWorkoutLogFromScratchCommandValidatorTests()
        {
            _random = new Random();
            _validator = new CreateWorkoutLogFromScratchCommandValidator();
            _workoutLogInput = new WorkoutLogInputScratchDto()
            {
                CustomName = _random.Next().ToString(),
                NoOfWeeks = _random.Next(),
                StartDate = DateTime.Now,
                UserId = _random.Next().ToString()
            };
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var userId = _random.Next().ToString();
            _workoutLogInput.UserId = userId;

            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, userId));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsNull_ReturnsValidationErrors()
        {
            _workoutLogInput.UserId = null;
            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsEmpty_ReturnsValidationErrors()
        {
            _workoutLogInput.UserId = "";
            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsNull_ReturnsValidationErrors()
        {
            _workoutLogInput.CustomName = null;
            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsEmpty_ReturnsValidationErrors()
        {
            var userId = _random.Next().ToString();
            _workoutLogInput.UserId = userId;
            _workoutLogInput.CustomName = "";

            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, userId));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsOver30Chars_ReturnsValidationErrors()
        {
            var userId = _random.Next().ToString();
            _workoutLogInput.UserId = userId;
            _workoutLogInput.CustomName = "".PadRight(100);

            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, userId));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_NoOfWeeksInvalid_ReturnsValidationErrors()
        {
            var userId = _random.Next().ToString();
            _workoutLogInput.UserId = userId;
            _workoutLogInput.NoOfWeeks = -66;

            var result = _validator.Validate(new CreateWorkoutLogFromScratchCommand(_workoutLogInput, userId));
            Assert.True(result.Errors.Any());
        }
    }
}
