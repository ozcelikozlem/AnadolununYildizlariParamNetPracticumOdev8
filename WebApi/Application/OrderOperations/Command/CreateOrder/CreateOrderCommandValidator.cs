using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Command.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command=> command.model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}