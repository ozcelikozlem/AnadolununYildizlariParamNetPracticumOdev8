using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Command.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(command=> command.model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}