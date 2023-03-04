using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext context;
    private readonly IMapper mapper;

    public CreateDirectorCommandTests(CommonTestFixture testFixture)
    {
        this.context = testFixture.Context;
        this.mapper = testFixture.Mapper;
    }

    [Fact]
    public void WhenAlreadyExitsDirectorFullNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        // arrange (Hazırlık)
        var director = new Director()
        {
            DirectorName = "Michaele",
            DirectorSurname = "Capuzzoo",
        };
        context.Directors.Add(director);
        context.SaveChanges();

        CreateDirectorCommand command = new(context, mapper);
        command.Model = new CreateDirectorModel { DirectorName = director.DirectorName, DirectorSurname = director.DirectorSurname};

        // act & assert (Çalıştırma - Doğrulama)
        FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director already exists.");

    }

    [Fact]
    public void WhenValidInputsAreGiven_Director_ShouldBeCreated()
    {
        // arrange
        CreateDirectorCommand command = new(context, mapper);
        CreateDirectorModel model = new CreateDirectorModel()
        {
            DirectorName ="Michaele",
            DirectorSurname="Capuzzoe",
        };

        command.Model = model;

        // act
        FluentActions.Invoking(() => command.Handle()).Invoke();
        // assert
        var author = context.Directors.SingleOrDefault(g => g.DirectorName== model.DirectorName && g.DirectorSurname == model.DirectorSurname);
        author.Should().NotBeNull();
        author.DirectorName.Should().Be(model.DirectorName);
        author.DirectorSurname.Should().Be(model.DirectorSurname);
        }
    }
}