using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorModel Model {get; set;}
        private readonly IMovieStoreDbContext _context;
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(director is null)
            {
                throw new InvalidOperationException("Director not found.");
            }
            if(_context.Directors.Any(x => x.DirectorName.ToLower() == Model.DirectorName.ToLower()&& x.DirectorSurname.ToLower() == Model.DirectorSurname.ToLower() && x.Id != DirectorId))
            {
                throw new InvalidOperationException("This Director Already Exists.");
            }
            director.DirectorName=string.IsNullOrEmpty(Model.DirectorName.Trim()) ? director.DirectorName : Model.DirectorSurname;
            director.DirectorSurname=string.IsNullOrEmpty(Model.DirectorSurname.Trim()) ? director.DirectorSurname : Model.DirectorSurname;
            _context.SaveChanges();
        }
    }
     public class UpdateDirectorModel
     {
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }

     }
}