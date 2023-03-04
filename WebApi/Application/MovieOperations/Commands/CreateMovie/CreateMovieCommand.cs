using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie =_dbContext.Movies.SingleOrDefault(x=> x.Title==Model.Title);
            if(movie is not null)
            {
                throw new InvalidOperationException("The movie already exists.");
            }
            movie = _mapper.Map<Movie>(Model); 

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public class CreateMovieViewModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int MovieYear { get; set; }
        public int MovieCost { get; set; }
        }
    }
}