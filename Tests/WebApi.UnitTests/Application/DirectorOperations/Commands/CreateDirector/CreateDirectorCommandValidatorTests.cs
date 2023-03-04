using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lor","")]
        [InlineData("","Lor")]
        [InlineData("Lor","Lor")]
        [InlineData("Loree","Lor")]
        [InlineData("Loree","")]
        [InlineData("","")]
        [InlineData("Lor","Loree")]
        [InlineData("","Loree")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string directorName, string directorSurname)
        {
            //arrange
           CreateDirectorCommand command = new CreateDirectorCommand(null,null);
           command.Model =new CreateDirectorModel()
           {
                DirectorName = directorName,
                DirectorSurname = directorSurname,
           };

            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        
        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model =new CreateDirectorModel()
            {
                DirectorName = "Lord",
                DirectorSurname ="Lord",
            };

            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}