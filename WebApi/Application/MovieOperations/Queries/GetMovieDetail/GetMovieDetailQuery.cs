using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId {get; set;}
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            Movie movie = _dbContext.Movies.Include(i=> i.MovieActressActors).ThenInclude(t=> t.ActressActor).Include(i => i.MovieDirectors).ThenInclude(t=> t.Director).SingleOrDefault(x => x.Id == MovieId);
            
            if(movie is null)
            {
                throw new InvalidOperationException("The movie not found.");
            }
            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
            return vm;
            
        }
    }
    public class MovieDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int MovieYear { get; set; }
        public int MovieCost { get; set; }
        public IReadOnlyCollection<string> Director { get; set; }
        public IReadOnlyList<string> ActressActor { get; set; }
    }
}