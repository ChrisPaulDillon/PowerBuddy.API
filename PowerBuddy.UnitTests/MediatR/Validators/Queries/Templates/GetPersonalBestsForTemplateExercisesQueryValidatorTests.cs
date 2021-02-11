using System;
using System.Linq;
using PowerBuddy.App.Queries.TemplatePrograms;
using PowerBuddy.App.Queries.Users;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Templates
{
    public class GetPersonalBestsForTemplateExercisesQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetPersonalBestsForTemplateExercisesQueryValidator _validator;

        public GetPersonalBestsForTemplateExercisesQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetPersonalBestsForTemplateExercisesQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetPersonalBestsForTemplateExercisesQuery(_random.Next(), _random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetPersonalBestsForTemplateExercisesQuery(_random.Next(), null));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_UsernameIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetPersonalBestsForTemplateExercisesQuery(_random.Next(), ""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidTemplateProgramId_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetPersonalBestsForTemplateExercisesQuery(-55, _random.Next().ToString()));
            Assert.True(result.Errors.Any());
        }
    }
}