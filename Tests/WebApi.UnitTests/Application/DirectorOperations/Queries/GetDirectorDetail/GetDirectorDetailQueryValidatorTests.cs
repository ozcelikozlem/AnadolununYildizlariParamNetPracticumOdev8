using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenDirectorIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int authorId )
        {
            //arrange
           GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
           query.DirectorId = authorId;

            //act
             GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDirectorIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           GetDirectorDetailQuery query = new GetDirectorDetailQuery(null,null);
           query.DirectorId = 3;

            //act
             GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);

        }

    }
}