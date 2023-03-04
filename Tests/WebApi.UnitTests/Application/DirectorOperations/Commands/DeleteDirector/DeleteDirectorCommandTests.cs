using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
          _context = testFixture.Context;
        }

         [Fact]
        public void WhenGivenDirectorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteDirectorCommand command =new DeleteDirectorCommand(_context);
            command.DirectorId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director not found.");

        }
        [Fact]
        public void WhenGivenDirectorHaveMovie_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)

            DeleteDirectorCommand command = new(_context);
            command.DirectorId = 1;

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The director has movies you can't delete!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeDeleted()
        {
            //arrange
            DeleteDirectorCommand command =new DeleteDirectorCommand(_context);
            command.DirectorId=1;

            //act
             DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}