using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.DirectorName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.DirectorSurname).NotEmpty().MinimumLength(2);
        }
       
    }
}