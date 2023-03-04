using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieActressActorOperation.Command.CreateMovieActressActor
{
    public class CreateMovieActressActorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActressActorMovieModel model;
        public CreateMovieActressActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actressActor = _dbContext.ActressActors.SingleOrDefault(s => s.Id == model.ActressActorId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var actressActorMovies = _dbContext.MovieActressActors.SingleOrDefault(s => s.ActressActorId == model.ActressActorId && s.MovieId == model.MovieId);

            if (actressActor is null)
                throw new InvalidOperationException("Actress or Actor not found");
            else if (movies is null)
                throw new InvalidOperationException("The movie not found");
            else if(actressActorMovies is not null)
                throw new InvalidOperationException("The actor or actress has acted in this movie before");

            MovieActressActor result = _mapper.Map<MovieActressActor>(model);

            _dbContext.MovieActressActors.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActressActorMovieModel
    {
        public int MovieId { get; set; }
        public int ActressActorId { get; set; }
    }
}