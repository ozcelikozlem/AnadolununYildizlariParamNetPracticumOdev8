using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail;
using WebApi.Application.ActressActorOperations.Queries.GetActressActors;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Queries.GetActressActorDetail
{
    public class GetActressActorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActressActorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenDirectorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            GetActressActorDetailQuery query =new GetActressActorDetailQuery(_context,_mapper);
            query.Id=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("This actress or actor not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeReturned()
        {
            // arrange
            GetActressActorDetailQuery query = new(_context, _mapper);
            query.Id = 1;

            var actor = _context.ActressActors.SingleOrDefault(a => a.Id == query.Id);

            // act
            GetActressActorDetailQueryViewModel vm = query.Handle();

            // assert
            vm.Should().NotBeNull();
            vm.ActressActorName.Should().Be(actor.ActressActorName);
            vm.ActressActorSurName.Should().Be(actor.ActressActorSurname);
        }
    }
}