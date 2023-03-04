using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.MovieDirector.Queries.GetMovieDirectorDetail
{
    public class GetMovieDirectorDetailQueryValidator : AbstractValidator<GetMovieDirectorDetailQuery>
    {
        public GetMovieDirectorDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}