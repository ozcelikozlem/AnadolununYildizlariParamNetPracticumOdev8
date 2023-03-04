using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenDirectorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetDirectorDetailQuery query =new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadi.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeReturned()
        {
            // arrange
            GetDirectorDetailQuery query = new(_context, _mapper);
            query.DirectorId = 1;

            var author = _context.Directors.SingleOrDefault(a => a.Id == query.DirectorId);

            // act
            DirectorDetailViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.DirectorName.Should().Be(author.DirectorName);
            vm.DirectorSurname.Should().Be(author.DirectorSurname);
        }
    }
}