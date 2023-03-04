using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        public readonly IMovieStoreDbContext _contex;
        public readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public List<DirectorsViewModel> Handle()
        {
            var directors = _contex.Directors.OrderBy(x => x.Id);
            List<DirectorsViewModel> returnObj = _mapper.Map<List<DirectorsViewModel>>(directors);
            return returnObj;
        }
    }
    public class DirectorsViewModel
    {
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
}