using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.ActressActorOperations.Command.DeleteActressActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.DeleteActressActor
{
    public class DeleteActressActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenDirectorIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int actressActorId )
        {
            //arrange
           DeleteActressActorCommand command = new DeleteActressActorCommand(null);
           command.Id = actressActorId;

            //act
             DeleteActressActorCommandValidator validator = new DeleteActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenBookIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteActressActorCommand command = new DeleteActressActorCommand(null);
           command.Id = 3;

            //act
             DeleteActressActorCommandValidator validator = new DeleteActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }

    }
    
}