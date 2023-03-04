using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActressActorOperations.Queries.GetActressActors
{
    public class GetActressActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActressActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActressActorsQueryViewModel> Handle()
        {
            List<ActressActor> actressActors = _context.ActressActors.OrderBy(x => x.Id).ToList();            
            List<GetActressActorsQueryViewModel> vm = _mapper.Map<List<GetActressActorsQueryViewModel>>(actressActors);

            return vm;
        }

    }

    public class GetActressActorsQueryViewModel
    {
        public string ActressActorName { get; set; }
        public string ActressActorSurName { get; set; }
    }

    
}