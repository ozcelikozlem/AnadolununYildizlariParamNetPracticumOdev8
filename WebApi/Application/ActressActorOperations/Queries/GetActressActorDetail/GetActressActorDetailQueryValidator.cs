using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.ActressActorOperations.Queries.GetActressActorDetail
{
    public class GetActressActorDetailQueryValidator : AbstractValidator<GetActressActorDetailQuery>
    {
        public GetActressActorDetailQueryValidator()
        {
             RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}