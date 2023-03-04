using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            List<Movie> movies = _dbContext.Movies.Include(i => i.MovieActressActors).ThenInclude(t=> t.ActressActor).Include(i => i.MovieDirectors).ThenInclude(t=> t.Director).OrderBy(x=> x.Id).ToList();                    
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movies);
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title { get; set; }
        public int MovieYear { get; set; }
        public int MovieCost { get; set; }
        public string Genre { get; set; }
        public IReadOnlyCollection<string> Director { get; set; }
        public IReadOnlyList<string> ActressActor { get; set; }
    }
}