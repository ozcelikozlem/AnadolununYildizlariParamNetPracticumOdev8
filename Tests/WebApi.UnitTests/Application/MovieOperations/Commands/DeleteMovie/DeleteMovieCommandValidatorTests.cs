using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenMovieIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int movieId )
        {
            //arrange
           DeleteMovieCommand command = new DeleteMovieCommand(null);
           command.MovieId = movieId;

            //act
             DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenMovieIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteMovieCommand command = new DeleteMovieCommand(null);
           command.MovieId = 3;

            //act
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}