using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ActressActorOperations.Queries.GetActressActors;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Queries.GetActressActors
{
    public class GetActressActorsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActressActorsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetActressesQuery_ActressList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetActressActorsQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result[0].ActressActorName.Should().Be("Anne");
            result[0].ActressActorSurName.Should().Be("Hathaway");

            result[1].ActressActorName.Should().Be("Helena");
            result[1].ActressActorSurName.Should().Be("Bonham Carter");

            result[2].ActressActorName.Should().Be("John Christopher");
            result[2].ActressActorSurName.Should().Be("Depp");

            result[3].ActressActorName.Should().Be("Mark");
            result[3].ActressActorSurName.Should().Be("Ruffalo");

            result[4].ActressActorName.Should().Be("Benedict");
            result[4].ActressActorSurName.Should().Be("Cumberbatch");

    }

    }
}