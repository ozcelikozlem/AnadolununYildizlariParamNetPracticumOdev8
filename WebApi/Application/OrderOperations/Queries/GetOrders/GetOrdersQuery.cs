using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<OrderMoviesViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.OrderCustomer).ThenInclude(t => t.Movie).Where(w => w.OrderCustomer.Any(a => a.IActive)).OrderBy(x => x.Id).ToList();
            List<OrderMoviesViewModel> vm = _mapper.Map<List<OrderMoviesViewModel>>(list);

            return vm;
        }
    }

    public class OrderMoviesViewModel
    {
        public string customerNameSurname { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
        public IReadOnlyCollection<string> Price { get; set; }
        public IReadOnlyCollection<string> OrderDate { get; set; }
    }
    
}