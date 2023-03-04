using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MovieDirector.Command.DeleteMovieDirector
{
    public class DeleteMovieDirectorCommandValidator : AbstractValidator<DeleteMovieDirectorCommand>
    {
        public DeleteMovieDirectorCommandValidator()
        {
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}