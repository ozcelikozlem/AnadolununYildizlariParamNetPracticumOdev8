using FluentValidation;

namespace WebApi.Application.MovieActressActorOperation.Command.CreateMovieActressActor
{
    public class CreateMovieActressActorCommandValidator : AbstractValidator<CreateMovieActressActorCommand>
    {
        public CreateMovieActressActorCommandValidator()
        {
            RuleFor(command=> command.model.ActressActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}