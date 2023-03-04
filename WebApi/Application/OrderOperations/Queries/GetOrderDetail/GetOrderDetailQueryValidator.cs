using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}