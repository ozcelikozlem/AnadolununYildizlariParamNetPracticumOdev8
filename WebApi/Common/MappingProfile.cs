using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using WebApi.Application.ActressActorOperations.Command.CreateActressActor;
using WebApi.Application.ActressActorOperations.Command.UpdateActressActor;
using WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail;
using WebApi.Application.ActressActorOperations.Queries.GetActressActors;
using WebApi.Application.CustomerOperations.Commands.UpdateUser;
using WebApi.Application.CustomerOperations.Queries.GetUserDetail;
using WebApi.Application.CustomerOperations.Queries.GetUsers;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.MovieActressActorOperation.Queries.GetActressActors;
using WebApi.Application.MovieDirector.Command.CreateMovieDirector;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.OrderOperations.Command.CreateOrder;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.Entities;
using static WebApi.Application.CustomerOperations.Commands.CreateUser.CreateUserCommand;
using static WebApi.Application.MovieDirector.Queries.GetMovieDirectors.GetMovieDirectorsQuery;
using static WebApi.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;


namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieViewModel,Movie>();
            CreateMap<CreateMovieViewModel,Movie>();
            CreateMap<Movie,MovieDetailViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name)).ForMember(dest => dest.ActressActor, opt => opt.MapFrom(m => m.MovieActressActors.Select(s => s.ActressActor.ActressActorName + " " + s.ActressActor.ActressActorSurname)))
                .ForMember(dest=> dest.Director, opt=> opt.MapFrom(m=> m.MovieDirectors.Select(s => s.Director.DirectorName + " " + s.Director.DirectorSurname)));

            CreateMap<Movie,MoviesViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name)).ForMember(dest => dest.ActressActor, opt => opt.MapFrom(m => m.MovieActressActors.Select(s => s.ActressActor.ActressActorName + " " + s.ActressActor.ActressActorSurname)))
                .ForMember(dest=> dest.Director, opt=> opt.MapFrom(m=> m.MovieDirectors.Select(s => s.Director.DirectorName + " " + s.Director.DirectorSurname)));
            CreateMap<UpdateMovieModel, Movie>();

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<UpdateGenreModel, Genre>();

            CreateMap<Director, DirectorDetailViewModel>();
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<UpdateDirectorModel, Director>();
            CreateMap<Director, DirectorsViewModel>();
            CreateMap<Director, GetDirectorMovieViewModel>()
                .ForMember(dest => dest.directorMovieNameSurname, opt => opt.MapFrom(m => m.DirectorName + " " + m.DirectorSurname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.MovieDirectors.Select(s => s.Movie.Title)));
            
            CreateMap<MovieDirectorModel, MoviesDirector>();

            CreateMap<ActressActor, GetActressActorsQueryViewModel>();
            CreateMap<CreateActressActorModel, ActressActor>();
            CreateMap<ActressActor, GetActressActorDetailQueryViewModel>();
            CreateMap<UpdateActressActorModel, ActressActor>();
             CreateMap<ActressActor, GetActressActorMovieViewModel>()
                .ForMember(dest => dest.ActressActorNameSurname, opt => opt.MapFrom(m => m.ActressActorName + " " + m.ActressActorSurname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.MovieActressActors.Select(s => s.Movie.Title)));

            CreateMap<CreateUserModel , Customer>();
             CreateMap<Customer, UsersViewModel>();
            CreateMap<Customer, UserDetailViewModel>();
            CreateMap<UpdateUserModel, Customer>();

            CreateMap<OrdersMoviesModel, Order>();
            CreateMap<Customer, OrderMoviesViewModel>()
                .ForMember(dest => dest.customerNameSurname , opt => opt.MapFrom(m => m.Name + " " + m.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.OrderCustomer.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.OrderCustomer.Select(s => s.Movie.MovieCost)))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(m => m.OrderCustomer.Select(s => s.dateofPurchase)));

        }
    }
}