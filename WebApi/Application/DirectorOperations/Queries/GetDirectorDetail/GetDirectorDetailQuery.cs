using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        public readonly IMovieStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetDirectorDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }
        public DirectorDetailViewModel Handle()
        {
            var director = _contex.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(director is null)
            {
                throw new InvalidOperationException("Director not found.");
            }
            return _mapper.Map<DirectorDetailViewModel>(director);
        }
    }
    public class DirectorDetailViewModel
    {
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
    }
}