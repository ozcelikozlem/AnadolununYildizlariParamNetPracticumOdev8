using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenDirectorIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int directorId )
        {
            //arrange
           DeleteDirectorCommand command = new DeleteDirectorCommand(null);
           command.DirectorId = directorId;

            //act
             DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenBookIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
           DeleteDirectorCommand command = new DeleteDirectorCommand(null);
           command.DirectorId = 3;

            //act
             DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }

}