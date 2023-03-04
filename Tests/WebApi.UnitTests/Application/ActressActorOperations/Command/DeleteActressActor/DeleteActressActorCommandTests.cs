using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ActressActorOperations.Command.DeleteActressActor;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.DeleteActressActor
{
    public class DeleteActressActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteActressActorCommandTests(CommonTestFixture testFixture)
        {
          _context = testFixture.Context;
        }

         [Fact]
        public void WhenGivenAcctressActorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteActressActorCommand command =new DeleteActressActorCommand(_context);
            command.Id=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("this actress or actor not found.");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeDeleted()
        {
            //arrange
            DeleteActressActorCommand command =new DeleteActressActorCommand(_context);
            command.Id=1;

            //act
             DeleteActressActorCommandValidator validator = new DeleteActressActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}