using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.MovieActressActorOperation.Queries.GetActressActors;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieActressActorOperation.Queries.GetActressActorDetail
{
    public class GetActressActorMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetActressActorMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public GetActressActorMovieViewModel Handle()
        {
            ActressActor actressActors = _dbContext.ActressActors.Include(i=> i.MovieActressActors).ThenInclude(t=> t.Movie).SingleOrDefault(x=> x.Id == Id);
            if(actressActors is null)
                throw new InvalidOperationException("This actress or actor not found");

            GetActressActorMovieViewModel vm = _mapper.Map<GetActressActorMovieViewModel>(actressActors);

            return vm;
        }
    }
}