using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.App.Commands.WorkoutExercises;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Commands.WorkoutExercises
{
    public class UpdateWorkoutExerciseNoteCommandValidatorTests
    {
        private readonly Random _random;
        private readonly UpdateWorkoutExerciseNotesCommandValidator _validator;

        public UpdateWorkoutExerciseNoteCommandValidatorTests()
        {
            _random = new Random();
            _validator = new UpdateWorkoutExerciseNotesCommandValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(_random.Next(), _random.Next().ToString(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(_random.Next(), _random.Next().ToString(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UserIdIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(_random.Next(), _random.Next().ToString(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_NotesIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(_random.Next(), "", _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }


        [Fact]
        public void CreateNew_NotesIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(_random.Next(), null, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidWorkoutExerciseId_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new UpdateWorkoutExerciseNotesCommand(-55, _random.Next().ToString(), _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}
