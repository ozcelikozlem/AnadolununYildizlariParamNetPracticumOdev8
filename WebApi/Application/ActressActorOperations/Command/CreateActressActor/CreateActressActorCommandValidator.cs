using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ActressActorOperations.Command.CreateActressActor
{
    public class CreateActressActorCommandValidator : AbstractValidator<CreateActressActorCommand>
    {
        public CreateActressActorCommandValidator()
        {
            RuleFor(command => command.Model.ActressActorName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.ActressActorSurName).NotEmpty().MinimumLength(2);
        }
    }
}