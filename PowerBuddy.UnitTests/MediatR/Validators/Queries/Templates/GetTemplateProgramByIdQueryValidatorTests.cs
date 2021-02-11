using System;
using System.Linq;
using PowerBuddy.App.Queries.TemplatePrograms;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Templates
{
    public class GetTemplateProgramByIdQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetTemplateProgramByIdQueryValidator _validator;

        public GetTemplateProgramByIdQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetTemplateProgramByIdQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetTemplateProgramByIdQuery(_random.Next()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_InvalidTemplateProgramId_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetTemplateProgramByIdQuery(-55));
            Assert.True(result.Errors.Any());
        }
    }
}
