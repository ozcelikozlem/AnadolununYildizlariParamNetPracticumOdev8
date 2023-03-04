using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MovieDirector.Command.UpdateMovieDirector
{
    public class UpdateMovieDirectorCommandValidator : AbstractValidator<UpdateMovieDirectorCommand>
    {
        public UpdateMovieDirectorCommandValidator()
        {
            RuleFor(command=> command.model.DirectorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}