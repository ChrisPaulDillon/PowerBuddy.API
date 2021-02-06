using System;
using System.Linq;
using PowerBuddy.App.Commands.WorkoutTemplates;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutTemplates
{
    public class DeleteWorkoutTemplateCommandValidatorTests
    {
        private readonly Random _random;
        private readonly DeleteWorkoutTemplateCommandValidator _validator;

        public DeleteWorkoutTemplateCommandValidatorTests()
        {
            _random = new Random();
            _validator = new DeleteWorkoutTemplateCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new DeleteWorkoutTemplateCommand(_random.Next(), _random.Next().ToString()));

            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutTemplateCommand(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutTemplateCommand(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_WorkoutTemplateIdIsInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new DeleteWorkoutTemplateCommand(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}