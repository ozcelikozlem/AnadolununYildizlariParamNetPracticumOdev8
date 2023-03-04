using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieActressActorOperation.Command.CreateMovieActressActor;
using WebApi.Application.MovieActressActorOperation.Command.DeleteMovieActressActor;
using WebApi.Application.MovieActressActorOperation.Command.UpdateMovieActressActor;
using WebApi.Application.MovieActressActorOperation.Queries.GetActressActorDetail;
using WebApi.Application.MovieActressActorOperation.Queries.GetActressActors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class movieActressActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public movieActressActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActressActorMovie()
        {
            GetActressActorMoviesQuery query = new GetActressActorMoviesQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetActorMovie(int id)
        {
            GetActressActorMovieDetailQuery query = new GetActressActorMovieDetailQuery(_dbContext, _mapper);
            query.Id = id;

            GetActressActorMovieDetailQueryValidator validator = new GetActressActorMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateActorMovie([FromBody] CreateActressActorMovieModel model)
        {
            CreateMovieActressActorCommand command = new CreateMovieActressActorCommand(_dbContext, _mapper);
            command.model = model;

            CreateMovieActressActorCommandValidator validator = new CreateMovieActressActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActorMovie([FromBody] UpdateActressActorMovieModel model, int Id)
        {
            UpdateActressActorMovieCommand command = new UpdateActressActorMovieCommand(_dbContext, _mapper);
            command.model = model;
            command.Id = Id;

            UpdateActressActorMovieCommandValidator validator = new UpdateActressActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActorMovie(int Id)
        {
            DeleteActressActorMovieCommand command = new DeleteActressActorMovieCommand(_dbContext);        
            command.Id = Id;

            DeleteActorMovieCommandValidator validator = new DeleteActorMovieCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }

}