using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActressActorOperations.Command.CreateActressActor;
using WebApi.Application.ActressActorOperations.Command.DeleteActressActor;
using WebApi.Application.ActressActorOperations.Command.UpdateActressActor;
using WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail;
using WebApi.Application.ActressActorOperations.Queries.GetActressActors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class actressActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public actressActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetActor()
        {
            GetActressActorsQuery query = new GetActressActorsQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActor(int id)
        {
            GetActressActorDetailQuery query = new GetActressActorDetailQuery(_context,_mapper);
            query.Id = id;

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActressActorModel model)
        {
            CreateActressActorCommand command = new CreateActressActorCommand(_context,_mapper);
            command.Model = model;

            CreateActressActorCommandValidator validator = new CreateActressActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody] UpdateActressActorModel model, int id)
        {
            UpdateActressActorCommand command = new UpdateActressActorCommand(_context);
            command.Model = model;
            command.Id = id;

            UpdateActressActorCommandValidator validator = new UpdateActressActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActressActorCommand command = new DeleteActressActorCommand(_context);            
            command.Id = id;

            DeleteActressActorCommandValidator validator = new DeleteActressActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}