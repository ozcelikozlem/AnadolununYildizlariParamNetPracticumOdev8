using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id;

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public OrderMoviesViewModel Handle()
        {
            Customer customer = _dbContext.Customers.Include(i => i.OrderCustomer).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == Id);
            OrderMoviesViewModel vm = _mapper.Map<OrderMoviesViewModel>(customer);

            return vm;
        }
    }
}