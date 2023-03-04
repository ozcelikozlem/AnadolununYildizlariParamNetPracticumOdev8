using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;
using static WebApi.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)
            var movie = new Movie(){Title="WhenAlreadyExistBookTitleIsGiven",GenreId=1,MovieCost=65,MovieYear=2022};
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command =new CreateMovieCommand(_context,_mapper);
            command.Model = new CreateMovieViewModel(){Title = movie.Title};

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The movie already exists.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            //arrange
            CreateMovieCommand command =new CreateMovieCommand(_context,_mapper);
            CreateMovieViewModel model = new CreateMovieViewModel(){Title="WhenAlreadyExistBookTitleIsGiven",GenreId=1,MovieCost=65,MovieYear=2022};
            command.Model = model;

            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var movie=_context.Movies.SingleOrDefault(m=> m.Title == model.Title);
            movie.Should().NotBeNull();
            movie.MovieCost.Should().Be(model.MovieCost);
            movie.MovieYear.Should().Be(model.MovieYear);
            movie.GenreId.Should().Be(model.GenreId);
        }
    }
}