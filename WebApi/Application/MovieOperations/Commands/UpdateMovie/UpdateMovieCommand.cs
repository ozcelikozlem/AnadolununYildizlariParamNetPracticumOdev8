using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int MovieId {get; set;}
        public UpdateMovieModel Model {get; set;}
        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie =_dbContext.Movies.SingleOrDefault(x=> x.Id==MovieId);
            if(movie is null)
             {
                throw new InvalidOperationException("The movie not found.");
            }
             movie.GenreId=Model.GenreId != default ? Model.GenreId : movie.GenreId;
             movie.Title=Model.Title != default ? Model.Title : movie.Title;
             movie.MovieCost=Model.MovieCost != default ? Model.MovieCost : movie.MovieCost;
             movie.MovieYear=Model.MovieYear != default ? Model.MovieYear : movie.MovieYear;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateMovieModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int MovieYear { get; set; }
        public int MovieCost { get; set; }
    }
}