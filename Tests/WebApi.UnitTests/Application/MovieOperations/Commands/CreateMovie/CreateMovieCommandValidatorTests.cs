using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static WebApi.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       [Theory]
        [InlineData("Lord Of The Rings",0,0,0)]
        [InlineData("Lord Of The Rings",0,1,1)]
        [InlineData("Lord Of The Rings",100,0,0)]
        [InlineData("",0,0,0)]
        [InlineData("",100,0,0)]
        [InlineData("",100,0,1)]
        [InlineData("",100,1,0)]
        [InlineData("",100,1,1)]
        [InlineData("Lor",100,0,0)]
        [InlineData("Lor",100,1,1)]
        //[InlineData("Lord Of The Rings",100,1,1)] --> successful case
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int movieCost, int movieYear, int genreId )
        {
            //arrange
           CreateMovieCommand command = new CreateMovieCommand(null,null);
           command.Model =new CreateMovieViewModel()
           {
                Title = title,
                MovieCost = movieCost,
                MovieYear = movieYear,
                GenreId = genreId
           };

            //act
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(null,null);
            command.Model =new CreateMovieViewModel()
            {
                Title = "Lord of The Rings",
                MovieCost = 200,
                MovieYear = 2010,
                GenreId = 1
            };

            //act
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}