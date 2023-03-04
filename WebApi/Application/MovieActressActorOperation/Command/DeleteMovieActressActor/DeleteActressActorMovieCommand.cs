using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieActressActorOperation.Command.DeleteMovieActressActor
{
    public class DeleteActressActorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id;
        public DeleteActressActorMovieCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            MovieActressActor actressActorMovies = _dbContext.MovieActressActors.SingleOrDefault(s => s.Id == Id);

            if (actressActorMovies is null)
                throw new InvalidOperationException("No related record found");
            
            _dbContext.MovieActressActors.Remove(actressActorMovies);
            _dbContext.SaveChanges();
        }
    }
}