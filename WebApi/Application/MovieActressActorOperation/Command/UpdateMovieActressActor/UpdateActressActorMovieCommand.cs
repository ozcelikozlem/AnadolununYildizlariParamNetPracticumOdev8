using System;
using System.Diagnostics.Contracts;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieActressActorOperation.Command.UpdateMovieActressActor
{
    public class UpdateActressActorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateActressActorMovieModel model;
        public int Id;
        public UpdateActressActorMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            ActressActor actor = _dbContext.ActressActors.SingleOrDefault(s => s.Id == model.ActressActorId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            MovieActressActor actressActorMovies = _dbContext.MovieActressActors.SingleOrDefault(s => s.Id == Id);

            if (actor is null)
                throw new InvalidOperationException("Actress or actor not found.");
            else if (movies is null)
                throw new InvalidOperationException("This movie not found");
            else if (actressActorMovies is null)
                throw new InvalidOperationException("No related record found");

            actressActorMovies.ActressActorId = model.ActressActorId == default ? actressActorMovies.ActressActorId : model.ActressActorId;
            actressActorMovies.MovieId = model.MovieId == default ? actressActorMovies.MovieId : model.MovieId;

            _dbContext.MovieActressActors.Update(actressActorMovies);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateActressActorMovieModel
    {
        public int MovieId { get; set; }
        public int ActressActorId { get; set; }
    }
}