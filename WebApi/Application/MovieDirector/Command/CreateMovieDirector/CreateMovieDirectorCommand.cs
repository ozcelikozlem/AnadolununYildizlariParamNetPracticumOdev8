using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieDirector.Command.CreateMovieDirector
{
    public class CreateMovieDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public MovieDirectorModel model;
        public CreateMovieDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(s => s.Id == model.DirectorId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var directorMovies = _dbContext.MoviesDirectors.SingleOrDefault(s => s.MovieId == model.MovieId);

            if (director is null)
                throw new InvalidOperationException("Director not found");
            else if (movies is null)
                throw new InvalidOperationException("Movie not found");
            else if(directorMovies is not null)
                throw new InvalidOperationException("This movie director available");

            MoviesDirector result = _mapper.Map<MoviesDirector>(model);

            _dbContext.MoviesDirectors.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class MovieDirectorModel
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
    }
    
}