using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.MovieActressActorOperation.Queries.GetActressActors
{
    public class GetActressActorMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActressActorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public List<GetActressActorMovieViewModel> Handle()
        {
            var actors = _dbContext.ActressActors.Include(i=> i.MovieActressActors).ThenInclude(t=> t.Movie).OrderBy(x=> x.Id).ToList();
            List<GetActressActorMovieViewModel> vm = _mapper.Map<List<GetActressActorMovieViewModel>>(actors);

            return vm;
        }
    }

    public class GetActressActorMovieViewModel
    {
        public string ActressActorNameSurname { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
}