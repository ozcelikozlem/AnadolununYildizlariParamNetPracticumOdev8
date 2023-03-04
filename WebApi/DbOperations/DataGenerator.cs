using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context =new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Action"
                    },
                    new Genre
                    {
                        Name="Animation"
                    },
                    new Genre
                    {
                        Name="Thriller"
                    },
                   new Genre
                    {
                        Name="Comedy"
                    },
                    new Genre
                    {
                        Name="Romance"
                    },
                    new Genre
                    {
                        Name="Science Fiction"
                    }

                );

                context.Directors.AddRange(
                    new Director
                    {
                        DirectorName ="Gore",
                        DirectorSurname="Verbinski",
                    },
                    new Director
                    {
                        DirectorName ="Louis",
                        DirectorSurname="Leterrier",
                    },
                    new Director
                    {
                        DirectorName ="Tim",
                        DirectorSurname="Burton",
                    },
                    new Director
                    {
                        DirectorName ="Gary",
                        DirectorSurname="Ross",
                    },
                    new Director
                    {
                        DirectorName ="Scott",
                        DirectorSurname="Derrickson",
                    }
                );
                context.ActressActors.AddRange(
                    new ActressActor
                    {
                        ActressActorName ="Anne",
                        ActressActorSurname="Hathaway",
                    },
                    new ActressActor
                    {
                        ActressActorName ="Helena",
                        ActressActorSurname="Bonham Carter",
                    },
                    new ActressActor
                    {
                        ActressActorName ="John Christopher",
                        ActressActorSurname="Depp",
                    },
                    new ActressActor
                    {
                        ActressActorName =" Mark",
                        ActressActorSurname="Ruffalo",
                    },
                    new ActressActor
                    {
                        ActressActorName =" Benedict",
                        ActressActorSurname="Cumberbatch",
                    }
                );


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
                context.MovieActressActors.AddRange(
                    new MovieActressActor
                    {
                        MovieId=1,
                        ActressActorId=3
                    },
                    new MovieActressActor
                    {
                        MovieId=1,
                        ActressActorId=4,
                    },
                    new MovieActressActor
                    {
                        MovieId=3,
                        ActressActorId=2,
                    },
                   new MovieActressActor
                    {
                        MovieId=3,
                        ActressActorId=3,
                    },
                    new MovieActressActor
                    {
                        MovieId=4,
                        ActressActorId=5,
                    },
                    new MovieActressActor
                    {
                        MovieId=5,
                        ActressActorId=1,
                    }
                    ,
                    new MovieActressActor
                    {
                        MovieId=5,
                        ActressActorId=2,
                    }

                );
                context.MoviesDirectors.AddRange(
                    new MoviesDirector
                    {
                        MovieId=1,
                        DirectorId=1
                    },
                    new MoviesDirector
                    {
                        MovieId=2,
                        DirectorId=2
                    },
                    new MoviesDirector
                    {
                        MovieId=3,
                        DirectorId=3
                    },
                   new MoviesDirector
                    {
                        MovieId=4,
                        DirectorId=4
                    },
                    new MoviesDirector
                    {
                        MovieId=5,
                        DirectorId=5
                    }
                );
                context.Customers.AddRange( 
                    new Customer
                    {
                        Name ="Özlem",
                        Surname="Özçelik",
                        Email="ozlm@gmail.com",
                        Password="1234"
                    }
                );

                context.SaveChanges();

            }
        }
    }
}