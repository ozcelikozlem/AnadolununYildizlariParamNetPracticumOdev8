using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public DeleteUserCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Customers.SingleOrDefault(x=> x.Id == CustomerId);
            if(user is null)
            {
                throw new InvalidOperationException("Kullanıcı Mevcut Değil");
            }
            _context.Customers.Remove(user);
            _context.SaveChanges();
        }
    }
}