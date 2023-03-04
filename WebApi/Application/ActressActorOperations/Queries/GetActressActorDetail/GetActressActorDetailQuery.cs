using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.ActressActorOperations.Queries.GetActressActors;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail
{
    public class GetActressActorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetActressActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetActressActorDetailQueryViewModel Handle()
        {
            ActressActor actressActor = _context.ActressActors.SingleOrDefault(x => x.Id == Id);
            if (actressActor is null)
                throw new InvalidOperationException("This actress or actor not found.");
            
            GetActressActorDetailQueryViewModel vm = _mapper.Map<GetActressActorDetailQueryViewModel>(actressActor);

            return vm;
        }
    }
    public class GetActressActorDetailQueryViewModel
    {
        public string ActressActorName { get; set; }
        public string ActressActorSurName { get; set; }
    }
}