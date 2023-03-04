using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Application.CustomerOperations.Commands.DeleteUser;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CustomerOperations.Commands.DeleteUser
{
    public class DeleteUserCommandTests : IClassFixture<CommonTestFixture>
    {
         private readonly MovieStoreDbContext _context;
        public DeleteUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenUserIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)

            DeleteUserCommand command =new DeleteUserCommand(_context);
            command.CustomerId=100;

            //act (Çalıştırma) & assert (Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı Mevcut Değil");

        }

        [Fact]
        public void WhenValidInputsAreGiven_User_ShouldBeDeleted()
        {
            //arrange
            DeleteUserCommand command =new DeleteUserCommand(_context);
            command.CustomerId=1;
            

            //act
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            var user=_context.Customers.SingleOrDefault(g=> g.Id == command.CustomerId);
            user.Should().BeNull();
        }
    }
}