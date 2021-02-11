using System;
using System.Linq;
using PowerBuddy.App.Queries.TemplatePrograms;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Templates
{
    public class GetTemplateProgramsBySearchQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetTemplateProgramsBySearchQueryValidator _validator;

        public GetTemplateProgramsBySearchQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetTemplateProgramsBySearchQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetTemplateProgramsBySearchQuery(_random.Next().ToString()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_SearchTermIsEmpty_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetTemplateProgramsBySearchQuery(""));
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_SearchTermIsNull_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetTemplateProgramsBySearchQuery(null));
            Assert.True(result.Errors.Any());
        }
    }
}
