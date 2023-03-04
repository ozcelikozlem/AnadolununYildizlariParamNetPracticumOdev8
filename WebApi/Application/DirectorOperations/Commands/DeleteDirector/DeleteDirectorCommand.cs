using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public DeleteDirectorCommand(IMovieStoreDbContext context)
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
            var movieDirector = _context.Movies.Where(x=> x.Id== DirectorId).ToList();
            if (movieDirector.Count>0)
            {
                throw new InvalidOperationException("The director has movies you can't delete!");
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}