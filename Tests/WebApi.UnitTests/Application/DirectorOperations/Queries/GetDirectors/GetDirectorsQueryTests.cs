using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetAuthorsQuery_AuthorList_ShouldBeReturned()
        {
            // Arrange
            var query = new GetDirectorsQuery(_context, _mapper);

            // Act
        var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result[0].DirectorName.Should().Be("Gore");
            result[0].DirectorSurname.Should().Be("Verbinski");

            result[1].DirectorName.Should().Be("Louis");
            result[1].DirectorSurname.Should().Be("Leterrier");

            result[2].DirectorName.Should().Be("Tim");
            result[2].DirectorSurname.Should().Be("Burton");

            result[3].DirectorName.Should().Be("Gary");
            result[3].DirectorSurname.Should().Be("Ross");

            result[4].DirectorName.Should().Be("Scott");
            result[4].DirectorSurname.Should().Be("Derrickson");



        }
    }
}