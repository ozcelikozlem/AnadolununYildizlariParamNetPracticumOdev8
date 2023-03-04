using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MovieDirector.Command.CreateMovieDirector
{
    public class CreateMovieDirectorCommandValidator : AbstractValidator<CreateMovieDirectorCommand>
    {
        public CreateMovieDirectorCommandValidator()
        {
            RuleFor(command=> command.model.DirectorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}