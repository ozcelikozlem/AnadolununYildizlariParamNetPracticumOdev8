using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }
        public DbSet<ActressActor> ActressActors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieActressActor> MovieActressActors { get; set; }
        public DbSet<MoviesDirector> MoviesDirectors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        int SaveChanges();
    }
}