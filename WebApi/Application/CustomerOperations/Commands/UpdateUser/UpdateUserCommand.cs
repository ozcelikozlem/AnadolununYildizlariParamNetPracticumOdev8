using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        public int UserId { get; set; }
        public UpdateUserModel Model {get; set;}
        private readonly IMovieStoreDbContext _context;
        public UpdateUserCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var user = _context.Customers.SingleOrDefault(x=> x.Id == UserId);
            if(user is null)
            {
                throw new InvalidOperationException("Kullanıcı Bulunamadı");
            }
            if(_context.Customers.Any(x => x.Email == Model.Email))
            {
                throw new InvalidOperationException("Aynı Isimli Kullanıcı Mevcut");
            }
            user.Name=string.IsNullOrEmpty(Model.Name.Trim()) ? user.Name : Model.Name;
            user.Surname=string.IsNullOrEmpty(Model.Name.Trim()) ? user.Surname : Model.Surname;
            user.Password=Model.Password;
            _context.SaveChanges();
        }
    }

    public class UpdateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}