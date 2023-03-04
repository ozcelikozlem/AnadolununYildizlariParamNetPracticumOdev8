using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.MovieDirector.Queries.GetMovieDirectors
{
    public class GetMovieDirectorsQuery
    {
        public class GetDirectorMoviesQuery
        {
            private readonly IMovieStoreDbContext _dbContext;
            private readonly IMapper _mapper;
            public GetDirectorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
            {
                _dbContext = context;
                _mapper = mapper;
            }
            public List<GetDirectorMovieViewModel> Handle()
            {
                var actors = _dbContext.Directors.Include(i=> i.MovieDirectors).ThenInclude(t=> t.Movie).OrderBy(x=> x.Id).ToList();
                List<GetDirectorMovieViewModel> vm = _mapper.Map<List<GetDirectorMovieViewModel>>(actors);

                return vm;
            }
    }

    public class GetDirectorMovieViewModel
    {
        public string directorMovieNameSurname { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
    }
}