using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ActressActorOperations.Command.DeleteActressActor
{
    public class DeleteActressActorCommandValidator: AbstractValidator<DeleteActressActorCommand>
    {
        public DeleteActressActorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}