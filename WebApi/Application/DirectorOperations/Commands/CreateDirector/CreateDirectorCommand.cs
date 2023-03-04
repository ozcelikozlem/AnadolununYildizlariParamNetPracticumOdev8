using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model {get; set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x=> x.DirectorName == Model.DirectorName && x.DirectorSurname == Model.DirectorSurname);
            if(director is not null)
            {
                throw new InvalidOperationException("Director already exists.");
            }
            director = _mapper.Map<Director>(Model);

            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }
    public class CreateDirectorModel
    {
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
    }
    
}