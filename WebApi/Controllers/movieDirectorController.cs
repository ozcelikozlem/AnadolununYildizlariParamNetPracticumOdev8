using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieDirector.Command.CreateMovieDirector;
using WebApi.Application.MovieDirector.Command.DeleteMovieDirector;
using WebApi.Application.MovieDirector.Command.UpdateMovieDirector;
using WebApi.Application.MovieDirector.Queries.GetMovieDirectorDetail;
using WebApi.DbOperations;
using static WebApi.Application.MovieDirector.Queries.GetMovieDirectors.GetMovieDirectorsQuery;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class movieDirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public movieDirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActorMovie()
        {
            GetDirectorMoviesQuery query = new GetDirectorMoviesQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetActorMovie(int id)
        {
            GetMovieDirectorDetailQuery query = new GetMovieDirectorDetailQuery(_dbContext, _mapper);
            query.Id = id;

            GetMovieDirectorDetailQueryValidator validator = new GetMovieDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateDirectorMovie([FromBody] MovieDirectorModel model)
        {
            CreateMovieDirectorCommand command = new CreateMovieDirectorCommand(_dbContext, _mapper);
            command.model = model;

            CreateMovieDirectorCommandValidator validator = new CreateMovieDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirectorMovie([FromBody] MovieDirectorModel model, int Id)
        {
            UpdateMovieDirectorCommand command = new UpdateMovieDirectorCommand(_dbContext, _mapper);
            command.model = model;
            command.Id = Id;

            UpdateMovieDirectorCommandValidator validator = new UpdateMovieDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirectorMovie(int Id)
        {
            DeleteMovieDirectorCommand command = new DeleteMovieDirectorCommand(_dbContext);        
            command.Id = Id;

            DeleteMovieDirectorCommandValidator validator = new DeleteMovieDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}