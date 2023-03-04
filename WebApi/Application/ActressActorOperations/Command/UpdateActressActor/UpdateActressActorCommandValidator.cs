using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ActressActorOperations.Command.UpdateActressActor
{
    public class UpdateActressActorCommandValidator : AbstractValidator<UpdateActressActorCommand>
    {
        public UpdateActressActorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.ActressActorName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(command => command.Model.ActressActorSurName).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}