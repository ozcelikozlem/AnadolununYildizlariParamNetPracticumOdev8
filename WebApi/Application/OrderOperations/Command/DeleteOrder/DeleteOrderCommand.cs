using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Command.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id;
        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            Order orderMovies = _dbContext.Orders.SingleOrDefault(s => s.Id == Id);
            if (orderMovies is null)
                throw new InvalidOperationException("No related record found");

            orderMovies.IActive = false;
            
            _dbContext.Orders.Update(orderMovies);
            _dbContext.SaveChanges();
        }
    }
}