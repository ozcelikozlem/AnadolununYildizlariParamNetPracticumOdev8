using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenMovieIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteMovieCommand command =new DeleteMovieCommand(_context);
            command.MovieId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The movie not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeDeleted()
        {
            //arrange
            DeleteMovieCommand command =new DeleteMovieCommand(_context);
            command.MovieId=1;
            

            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var movie=_context.Movies.SingleOrDefault(m=> m.Id == command.MovieId);
            movie.Should().BeNull();
        }
    }
    
}