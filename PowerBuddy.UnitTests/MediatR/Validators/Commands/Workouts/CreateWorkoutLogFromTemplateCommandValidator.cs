using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.App.Commands.Workouts;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.Workouts
{
    public class CreateWorkoutLogFromTemplateCommandValidatorTests
    {
        private readonly Random _random;
        private readonly CreateWorkoutLogFromTemplateCommandValidator _validator;

        private readonly WorkoutLogTemplateInputDto _workoutLogInput;

        public CreateWorkoutLogFromTemplateCommandValidatorTests()
        {
            _random = new Random();
            _validator = new CreateWorkoutLogFromTemplateCommandValidator();
            _workoutLogInput = new WorkoutLogTemplateInputDto()
            {
                CustomName = _random.Next().ToString(),
                StartDate = DateTime.Now,
                UserId = _random.Next().ToString(),
                Monday = false,
                Tuesday = false,
                Wednesday = false,
                Thursday = false,
                Friday = false,
                Saturday = false,
                Sunday = false,
                DayCount = _random.Next(),
                WeightInputs = new List<TemplateWeightInputDto>() { new TemplateWeightInputDto() }
            };
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(),null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsNull_ReturnsValidationErrors()
        {
            _workoutLogInput.UserId = null;
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutUserIdIsEmpty_ReturnsValidationErrors()
        {
            _workoutLogInput.UserId = "";
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(),_random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsNull_ReturnsValidationErrors()
        {
            _workoutLogInput.CustomName = null;
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsEmpty_ReturnsValidationErrors()
        {
            _workoutLogInput.CustomName = "";
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_CustomNameIsOver30Chars_ReturnsValidationErrors()
        {
            _workoutLogInput.CustomName = "".PadRight(100);
            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_NoWeightInputsProvided_ReturnsValidationErrors()
        {
            var templateWeightInputDtos = new List<TemplateWeightInputDto>();
            _workoutLogInput.WeightInputs = templateWeightInputDtos;

            var result = _validator.Validate(new CreateWorkoutLogFromTemplateCommand(_workoutLogInput, _random.Next(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}