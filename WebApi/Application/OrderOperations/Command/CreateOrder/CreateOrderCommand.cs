using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Command.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrdersMoviesModel model;
        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var ordersMovie = _dbContext.Orders.SingleOrDefault(s => s.CustomerId == model.CustomerId && s.MovieId == model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Customer not found");
            else if (movies is null)
                throw new InvalidOperationException("Movie not found");
            else if (ordersMovie is not null)
                throw new InvalidOperationException("Customer already bought");

            Order result = _mapper.Map<Order>(model);
            result.dateofPurchase = DateTime.Now;
            result.IActive = true;

            _dbContext.Orders.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class OrdersMoviesModel
    {
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        DateTime dateofPurchase = DateTime.Now;
        bool IActive = true;
    }
    
}