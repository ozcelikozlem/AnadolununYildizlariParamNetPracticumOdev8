using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.ActressActorOperations.Command.UpdateActressActor;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.UpdateActressActor
{
    public class UpdateActressActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"Lord Of The Rings"," ")]
        [InlineData(0,"Lord Of The Rings","Lor")]
        [InlineData(0,"Lor","lor")]
        [InlineData(0," ","lordd")]
        [InlineData(-5,"Lord Of The Rings"," ")]
        [InlineData(-5,"Lord Of The Rings","Lor")]
        [InlineData(-5,"Lor","lor")]
        [InlineData(-5," ","lordd")]
        [InlineData(1,"Lord Of The Rings"," ")]
        [InlineData(1,"Lord Of The Rings","Lor")]
        [InlineData(1,"Lor","lor")]
        [InlineData(1," ","lordd")]
        //[InlineData(1,"Lord Of The Rings",1,1)] --> successful case
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int actressActorId,string actressActorName, string actressActorSurname )
        {
            //arrange
           UpdateActressActorCommand command = new UpdateActressActorCommand(null);
           command.Model =new UpdateActressActorModel()
           {
                ActressActorName = actressActorName,
                ActressActorSurName = actressActorSurname

           };
           command.Id = actressActorId;

            //act
            UpdateActressActorCommandValidator validator = new UpdateActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateActressActorCommand command = new UpdateActressActorCommand(null);
            command.Model =new UpdateActressActorModel()
            {
                ActressActorName = "Frank",
                ActressActorSurName = "Herbert",
            };
            command.Id = 3;
            
            //act
            UpdateActressActorCommandValidator validator = new UpdateActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}