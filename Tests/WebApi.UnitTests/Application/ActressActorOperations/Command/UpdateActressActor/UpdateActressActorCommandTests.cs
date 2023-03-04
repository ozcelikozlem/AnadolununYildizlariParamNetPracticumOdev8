using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.ActressActorOperations.Command.UpdateActressActor;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.UpdateActressActor
{
    public class UpdateActressActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateActressActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenActressActorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            UpdateActressActorCommand command =new UpdateActressActorCommand(_context);
            command.Id=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("This actress or actor not found.");

        }
        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeUpdated()
        {
            //arrange
            UpdateActressActorCommand command =new UpdateActressActorCommand(_context);
            UpdateActressActorModel model = new UpdateActressActorModel(){ActressActorName ="Franak",ActressActorSurName ="Herbeart"};
            command.Model = model;
            command.Id=3;
            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var actressActor=_context.ActressActors.SingleOrDefault(a=> a.Id == command.Id);
            actressActor.Should().NotBeNull();
            actressActor.ActressActorName.Should().Be(model.ActressActorName);
            actressActor.ActressActorSurname.Should().Be(model.ActressActorSurName);
        }
    }


}