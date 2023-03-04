using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.OrderOperations.Command.CreateOrder;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Command.UpdateOrder
{
    public class UpdateOrderCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrdersMoviesModel model;
        public int Id;
        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            Order orderMovieCheck  = _dbContext.Orders.Single(s => s.CustomerId == model.CustomerId && s.MovieId == model.MovieId);
            Order orderMovies = _dbContext.Orders.SingleOrDefault(s => s.Id == Id);

            if (customer is null)
                throw new InvalidOperationException("Customer not found");
            else if (movies is null)
                throw new InvalidOperationException("Movie not found");
            else if (orderMovieCheck is not null)
                throw new InvalidOperationException("Customer already bought!");
            else if(orderMovies is null)
                throw new InvalidOperationException("No related record found");

            orderMovies.CustomerId = model.CustomerId == default ? orderMovies.CustomerId : model.CustomerId;
            orderMovies.MovieId = model.MovieId == default ? orderMovies.MovieId : model.MovieId;

            _dbContext.Orders.Update(orderMovies);
            _dbContext.SaveChanges();
        }
    }
}