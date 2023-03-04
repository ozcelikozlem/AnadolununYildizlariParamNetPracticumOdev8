using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CustomerOperations.Commands.DeleteUser;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CustomerOperations.Commands.DeleteUser
{
    public class DeleteUserCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenUserIdBeZeroOrLessThenZero_Validator_ShouldBeReturnErrors(int customerId )
        {
            //arrange
           DeleteUserCommand command = new DeleteUserCommand(null);
           command.CustomerId= customerId;

            //act
             DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenUserIdBeGreaterThanZero_Validator_ShouldBeReturnErrors()
        {
            //arrange
            DeleteUserCommand command = new DeleteUserCommand(null);
            command.CustomerId = 1;

            //act
            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }
    }
}