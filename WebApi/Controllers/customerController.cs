using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.CreateUser;
using WebApi.Application.CustomerOperations.Commands.DeleteUser;
using WebApi.Application.CustomerOperations.Commands.ResfreshToken;
using WebApi.Application.CustomerOperations.Commands.UpdateUser;
using WebApi.Application.CustomerOperations.Queries.GetUserDetail;
using WebApi.Application.CustomerOperations.Queries.GetUsers;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;
using static WebApi.Application.CustomerOperations.Commands.CreateToken.CreateTokenCommand;
using static WebApi.Application.CustomerOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class customerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public customerController(IMapper mapper, IConfiguration configuration, IMovieStoreDbContext context)
        {

            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command =new CreateUserCommand(_context,_mapper);
            command.Model=newUser;
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken ([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;

        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken ([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;

        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            GetUsersQuery query = new GetUsersQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetUserDetail(int id)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(_context,_mapper);
            query.UserId =id;
            GetUserDetailQueryValidator validator = new GetUserDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel updateUser)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);
            command.UserId=id;
            command.Model = updateUser;

            UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.CustomerId=id;

            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}