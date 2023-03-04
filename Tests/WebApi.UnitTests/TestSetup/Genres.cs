using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
            new Genre{Name="Action"},
            new Genre{Name="Animation"},
            new Genre{Name="Thriller"},
            new Genre{Name="Comedy"},
            new Genre{Name="Romance"},
            new Genre{Name="Science Fiction"}
            );
        }
    }
}