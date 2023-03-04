using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenMovieIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int movieId )
        {
            //arrange
           GetMovieDetailQuery query = new GetMovieDetailQuery(null,null);
           query.MovieId = movieId;

            //act
             GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenMovieIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetMovieDetailQuery query = new GetMovieDetailQuery(null,null);
           query.MovieId = 3;

            //act
            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}