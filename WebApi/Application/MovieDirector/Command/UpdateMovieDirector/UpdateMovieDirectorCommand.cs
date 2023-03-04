using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.MovieDirector.Command.CreateMovieDirector;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieDirector.Command.UpdateMovieDirector
{
    public class UpdateMovieDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public MovieDirectorModel model;
        public int Id;
        public UpdateMovieDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Director director = _dbContext.Directors.SingleOrDefault(s => s.Id == model.DirectorId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            MoviesDirector directorMovies = _dbContext.MoviesDirectors.SingleOrDefault(s => s.Id == Id);

            if (director is null)
                throw new InvalidOperationException("Director not found");
            else if (movies is null)
                throw new InvalidOperationException("Movie not found");
            else if(directorMovies is null)
                throw new InvalidOperationException("No data available in the relevant record");

            directorMovies.DirectorId = model.DirectorId == default ? directorMovies.DirectorId : model.DirectorId;
            directorMovies.MovieId = model.MovieId == default ? directorMovies.MovieId : model.MovieId;

            _dbContext.MoviesDirectors.Update(directorMovies);
            _dbContext.SaveChanges();
        }
    }
}