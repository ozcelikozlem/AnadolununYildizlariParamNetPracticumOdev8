using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenMovieIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateMovieCommand command =new UpdateMovieCommand(_context);
            command.MovieId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The movie not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            //arrange
            UpdateMovieCommand command =new UpdateMovieCommand(_context);
            UpdateMovieModel model = new UpdateMovieModel(){Title ="Hobbit",GenreId=1,MovieCost=200,MovieYear=1999};
            command.Model = model;
            command.MovieId=1;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var movie=_context.Movies.SingleOrDefault(m=> m.Id == command.MovieId);
            movie.Should().NotBeNull();
            movie.GenreId.Should().Be(model.GenreId);
            movie.MovieCost.Should().Be(model.MovieCost);
            movie.MovieYear.Should().Be(model.MovieYear);
            movie.Title.Should().Be(model.Title);
        }
    }
}