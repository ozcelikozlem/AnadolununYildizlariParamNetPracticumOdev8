using FluentValidation;

namespace WebApi.Application.MovieActressActorOperation.Command.UpdateMovieActressActor
{
    public class UpdateActressActorMovieCommandValidator : AbstractValidator<UpdateActressActorMovieCommand>
    {
        public UpdateActressActorMovieCommandValidator()
        {
            RuleFor(command=> command.model.ActressActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}