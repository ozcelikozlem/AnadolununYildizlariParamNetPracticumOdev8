using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetMoviesQuery_MovieList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetMoviesQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();

            result[0].Title.Should().Be("Pirates of the Caribbean");
            result[0].Genre.Should().Be("Action");
            result[0].MovieCost.Should().Be(55);
            result[0].MovieYear.Should().Be(2003);

            result[1].Title.Should().Be("Now You See Me");
            result[1].Genre.Should().Be("Thriller");
            result[1].MovieCost.Should().Be(55);
            result[1].MovieYear.Should().Be(2013);

            result[2].Title.Should().Be("Corpse Bride");
            result[2].Genre.Should().Be("Animation");
            result[2].MovieCost.Should().Be(55);
            result[2].MovieYear.Should().Be(2005);

            result[3].Title.Should().Be("Doctor Strange");
            result[3].Genre.Should().Be("Science Fiction");
            result[3].MovieCost.Should().Be(55);
            result[3].MovieYear.Should().Be(2016);

            result[4].Title.Should().Be("Ocean's 8");
            result[4].Genre.Should().Be("Action");
            result[4].MovieCost.Should().Be(55);
            result[4].MovieYear.Should().Be(2018);
        }
    }
}