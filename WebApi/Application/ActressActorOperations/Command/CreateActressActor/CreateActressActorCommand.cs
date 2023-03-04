using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActressActorOperations.Command.CreateActressActor
{
    public class CreateActressActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActressActorModel Model;

        public CreateActressActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var result = _mapper.Map<ActressActor>(Model);
            
            _context.ActressActors.Add(result);
            _context.SaveChanges();
        }
    }

    public class CreateActressActorModel
    {
        public string ActressActorName { get; set; }
        public string ActressActorSurName { get; set; }
    }
    
}