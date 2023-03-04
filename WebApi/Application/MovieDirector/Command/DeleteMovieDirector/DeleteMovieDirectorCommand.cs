using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieDirector.Command.DeleteMovieDirector
{
    public class DeleteMovieDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id;
        public DeleteMovieDirectorCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            MoviesDirector moviesDirector= _dbContext.MoviesDirectors.SingleOrDefault(s => s.Id == Id);

            if (moviesDirector is null)
                throw new InvalidOperationException("No data available in the relevant record");
            
            _dbContext.MoviesDirectors.Remove(moviesDirector);
            _dbContext.SaveChanges();
        }
    }
}