using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMovieDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenMovieIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetMovieDetailQuery query =new GetMovieDetailQuery(_context,_mapper);
            query.MovieId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The movie not found.");

        }

         [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeReturned()
        {
            // arrange
            GetMovieDetailQuery query = new(_context, _mapper);
            query.MovieId = 1;

            var movie = _context.Movies.Include(i=> i.MovieActressActors).ThenInclude(t=> t.ActressActor).Include(i => i.MovieDirectors).ThenInclude(t=> t.Director).SingleOrDefault(x => x.Id ==query.MovieId);

            // act
            MovieDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.Title.Should().Be(movie.Title);
            vm.MovieCost.Should().Be(movie.MovieCost);
            vm.MovieYear.Should().Be(movie.MovieYear);
            vm.Genre.Should().Be(movie.Genre.Name);
        }
    }
}