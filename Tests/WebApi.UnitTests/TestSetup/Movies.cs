using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange( 
                    new Movie
                    {
                        Title= "Pirates of the Caribbean",
                        GenreId=1,
                        MovieYear=2003,
                        MovieCost=55
                    },
                    new Movie
                    {
                        Title= "Now You See Me",
                        GenreId=3,
                        MovieYear=2013,
                        MovieCost=55
                        
                    },
                    new Movie
                    {
                        Title= "Corpse Bride",
                        GenreId=2,
                        MovieYear=2005,
                        MovieCost=55
                        
                    },
                    new Movie
                    {
                        Title= "Doctor Strange",
                        GenreId=6,
                        MovieYear=2016,
                        MovieCost=55
                    },
                    new Movie
                    {
                        Title= "Ocean's 8",
                        GenreId=1,
                        MovieYear=2018,
                        MovieCost=55
                    }
                );
        }
    }
}