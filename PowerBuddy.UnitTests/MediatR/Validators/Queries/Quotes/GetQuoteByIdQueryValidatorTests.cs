using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.App.Queries.Quotes;
using PowerBuddy.App.Queries.Users;
using Xunit;

namespace PowerBuddy.UnitTests.MediatR.Validators.Queries.Quotes
{
    public class GetQuoteByIdQueryValidatorTests
    {
        private readonly Random _random;
        private readonly GetQuoteByIdQueryValidator _validator;

        public GetQuoteByIdQueryValidatorTests()
        {
            _random = new Random();
            _validator = new GetQuoteByIdQueryValidator();
        }

        [Fact]
        public void CreateNew_ValidParameters_Passes()
        {
            var result = _validator.Validate(new GetQuoteByIdQuery(_random.Next()));
            Assert.False(result.Errors.Any());
        }

        [Fact]
        public void CreateNew_QuoteIdInvalid_ReturnsValidationErrors()
        {
            var result = _validator.Validate(new GetQuoteByIdQuery(-55));
            Assert.True(result.Errors.Any());
        }
    }
}