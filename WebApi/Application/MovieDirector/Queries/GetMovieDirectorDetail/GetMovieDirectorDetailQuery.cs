using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.MovieDirector.Queries.GetMovieDirectors.GetMovieDirectorsQuery;

namespace WebApi.Application.MovieDirector.Queries.GetMovieDirectorDetail
{
    public class GetMovieDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetMovieDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public GetDirectorMovieViewModel Handle()
        {
            Director director = _dbContext.Directors.Include(i=> i.MovieDirectors).ThenInclude(t=> t.Movie).SingleOrDefault(s=> s.Id == Id);
            if(director is null)
                throw new InvalidOperationException("Director not found");

            GetDirectorMovieViewModel vm = _mapper.Map<GetDirectorMovieViewModel>(director);

            return vm;
        }
    }
}