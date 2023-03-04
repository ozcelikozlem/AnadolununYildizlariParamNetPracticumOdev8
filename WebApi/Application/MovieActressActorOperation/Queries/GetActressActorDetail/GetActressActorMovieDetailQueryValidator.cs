using FluentValidation;

namespace WebApi.Application.MovieActressActorOperation.Queries.GetActressActorDetail
{
    public class GetActressActorMovieDetailQueryValidator : AbstractValidator<GetActressActorMovieDetailQuery>
    {
        public GetActressActorMovieDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}