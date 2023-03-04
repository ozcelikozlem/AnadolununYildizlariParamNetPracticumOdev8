using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
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
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int directorId,string directorName, string directorSurname )
        {
            //arrange
           UpdateDirectorCommand command = new UpdateDirectorCommand(null);
           command.Model =new UpdateDirectorModel()
           {
                DirectorName = directorName,
                DirectorSurname = directorSurname

           };
           command.DirectorId = directorId;

            //act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.Model =new UpdateDirectorModel()
            {
                DirectorName = "Frank",
                DirectorSurname = "Herbert",
            };
            command.DirectorId = 3;
            
            //act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}