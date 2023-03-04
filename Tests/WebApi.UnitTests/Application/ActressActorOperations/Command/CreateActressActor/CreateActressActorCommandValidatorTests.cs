using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.ActressActorOperations.Command.CreateActressActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.CreateActressActor
{
    public class CreateActressActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        [InlineData("","test1")]
        [InlineData("test2","")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErorrs(string name, string surName)
        {
            //arrange
            CreateActressActorCommand command = new CreateActressActorCommand(null,null);
            command.Model = new CreateActressActorModel()
            {
                ActressActorName = name,
                ActressActorSurName = surName
            };

            //act
            CreateActressActorCommandValidator validator = new CreateActressActorCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateActressActorCommand command = new CreateActressActorCommand(null,null);
            command.Model =new CreateActressActorModel()
            {
                ActressActorName = "Lord",
                ActressActorSurName ="Lord",
            };

            //act
            CreateActressActorCommandValidator validator = new CreateActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }

    }
}