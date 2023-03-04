using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenDirectorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateDirectorCommand command =new UpdateDirectorCommand(_context);
            command.DirectorId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeUpdated()
        {
            //arrange
            UpdateDirectorCommand command =new UpdateDirectorCommand(_context);
            UpdateDirectorModel model = new UpdateDirectorModel(){DirectorName ="Franak",DirectorSurname ="Herbeart"};
            command.Model = model;
            command.DirectorId=3;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var director=_context.Directors.SingleOrDefault(a=> a.Id == command.DirectorId);
            director.Should().NotBeNull();
            director.DirectorName.Should().Be(model.DirectorName);
            director.DirectorSurname.Should().Be(model.DirectorSurname);
        }
    }
}