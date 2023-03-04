using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName:"MovieStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddGenres();
            Context.AddMovies();
            Context.AddDirectors();
            Context.AddActressActors();
            Context.AddOrders();
            Context.AddCustomers();

            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg=> {cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}