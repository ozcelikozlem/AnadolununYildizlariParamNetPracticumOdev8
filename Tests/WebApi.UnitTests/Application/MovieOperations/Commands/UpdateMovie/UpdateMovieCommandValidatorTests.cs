using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"Lord Of The Rings",0,0,0)]
        [InlineData(0,"Lord Of The Rings",0,1,1)]
        [InlineData(0,"Lord Of The Rings",1,1,0)]
        [InlineData(0,"Lor",1,1,0)]
        [InlineData(0,"",1,1,1)]
        [InlineData(-5,"Lord Of The Rings",0,0,0)]
        [InlineData(-5,"Lord Of The Rings",0,1,1)]
        [InlineData(-5,"Lord Of The Rings",1,1,0)]
        [InlineData(-5,"Lor",1,1,1)]
        [InlineData(-5,"",1,1,0)]
        [InlineData(1,"Lord Of The Rings",0,0,0)]
        [InlineData(1,"",0,0,0)]
        [InlineData(1,"",1,0,1)]
        [InlineData(1,"",0,1,1)]
        [InlineData(1,"",1,1,0)]
        [InlineData(1,"Lor",1,0,1)]
        [InlineData(1,"Lor",0,1,1)]
        [InlineData(1,"Lor",1,1,0)]
        //[InlineData(1,"Lord Of The Rings",1,1,1)] --> successful case
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int movieId,string title, int genreId, int movieCost ,int movieYear)
        {
            //arrange
           UpdateMovieCommand command = new UpdateMovieCommand(null);
           command.Model =new UpdateMovieModel()
           {
                Title = title,
                GenreId = genreId,
                MovieCost = movieCost,
                MovieYear=movieYear
           };
           command.MovieId = movieId;

            //act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Model =new UpdateMovieModel()
            {
                Title = "Lord of The Rings",
                GenreId = 1,
                MovieCost = 100,
                MovieYear=2002
            };
            command.MovieId = 3;
            
            //act
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}