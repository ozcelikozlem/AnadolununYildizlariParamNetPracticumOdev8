using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Command.CreateOrder;
using WebApi.Application.OrderOperations.Command.DeleteOrder;
using WebApi.Application.OrderOperations.Command.UpdateOrder;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class orderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public orderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrderMovies()
        {
            GetOrdersQuery query = new GetOrdersQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderMoviesDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_dbContext, _mapper);
            query.Id = id;

            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateOrderMovies([FromBody] OrdersMoviesModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.model = model;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderMovies([FromBody] OrdersMoviesModel model, int Id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_dbContext, _mapper);
            command.model = model;
            command.Id = Id;

            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderMovies(int Id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_dbContext);        
            command.Id = Id;

            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}