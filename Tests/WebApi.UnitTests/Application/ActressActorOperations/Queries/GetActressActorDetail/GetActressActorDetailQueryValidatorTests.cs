using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Queries.GetActressActorDetail
{
    public class GetActressActorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenActorIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int actorId )
        {
            //arrange
           GetActressActorDetailQuery query = new GetActressActorDetailQuery(null,null);
           query.Id = actorId;

            //act
             GetActressActorDetailQueryValidator validator = new GetActressActorDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDirectorIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetActressActorDetailQuery query = new GetActressActorDetailQuery(null,null);
           query.Id = 3;

            //act
             GetActressActorDetailQueryValidator validator = new GetActressActorDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}