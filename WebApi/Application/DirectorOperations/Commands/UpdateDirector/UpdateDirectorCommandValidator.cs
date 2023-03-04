using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator: AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.DirectorName).MinimumLength(4).When(x => x.Model.DirectorName != string.Empty);
            RuleFor(command => command.Model.DirectorSurname).MinimumLength(4).When(x => x.Model.DirectorSurname != string.Empty);
            
        }
    }
}