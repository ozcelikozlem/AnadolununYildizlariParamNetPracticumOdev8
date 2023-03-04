using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using Microsoft.AspNetCore.Authorization;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using static WebApi.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;

namespace WebApi.AddControllers
    {
        [Authorize]
        [ApiController]
        [Route("api/[controller]s")]
        public class movieController : ControllerBase
        {
            private readonly IMovieStoreDbContext _context;
            private readonly IMapper _mapper;
            public movieController(IMovieStoreDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet] // GET: api/books
            public IActionResult GetMovies()
            {
                GetMoviesQuery query = new GetMoviesQuery(_context,_mapper);
                var result = query.Handle();
                return Ok(result);
            }

           
            [HttpGet("{id}")] 
            public IActionResult GetMovieById(int id)
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
                query.MovieId =id;
                GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
                validator.ValidateAndThrow(query);
                var result =query.Handle();
                return Ok(result);
            }

            [HttpPost]
            public IActionResult AddMovie([FromBody] CreateMovieViewModel newMovie)
            {
                CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
                command.Model = newMovie;
                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updatedBook)
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_context);
                command.MovieId=id;
                command.Model=updatedBook;
                UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
                
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMovie(int id)
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId=id;
                DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }


        }
    }