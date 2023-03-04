using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.ActressActorOperations.Command.CreateActressActor;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.ActressActorOperations.Command.CreateActressActor
{
    public class CreateActressActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActressActorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        
        [Fact]
        public void WhenActressActorModelIsGiven_Create_ShouldBeCreateActressActor()
        {
            // arrange
            CreateActressActorModel model = new CreateActressActorModel() { ActressActorName = "actressTest", ActressActorSurName = "actressTest"};
            CreateActressActorCommand command = new CreateActressActorCommand(_dbContext, _mapper);
            command.Model = model;
        
            // act
            FluentActions
                .Invoking(()=> command.Handle()).Invoke();
        
            // assert
            var actor = _dbContext.ActressActors.SingleOrDefault(s => s.ActressActorName == model.ActressActorName && s.ActressActorName == model.ActressActorSurName);
            
            actor.Should().NotBeNull();
            actor.ActressActorName.Should().Be(model.ActressActorName);
            actor.ActressActorName.Should().Be(model.ActressActorName);
        }
        [Fact]
        public void WhenValidInputsAreGiven_ActressActor_ShouldBeCreated()
        {
            //arrange
            CreateActressActorCommand command =new CreateActressActorCommand(_dbContext,_mapper);
            CreateActressActorModel model = new CreateActressActorModel(){ActressActorName="Test",ActressActorSurName="Test"};
            command.Model = model;

            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var actressActor=_dbContext.ActressActors.SingleOrDefault(g=> g.ActressActorName == model.ActressActorName && g.ActressActorSurname == model.ActressActorSurName );
            actressActor.Should().NotBeNull();
            actressActor.ActressActorName.Should().Be(model.ActressActorName);
            actressActor.ActressActorSurname.Should().Be(model.ActressActorSurName);
        }
    }
    
}