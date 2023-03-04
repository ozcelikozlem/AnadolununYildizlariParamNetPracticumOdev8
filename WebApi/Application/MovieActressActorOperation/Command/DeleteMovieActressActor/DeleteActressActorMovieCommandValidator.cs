using FluentValidation;

namespace WebApi.Application.MovieActressActorOperation.Command.DeleteMovieActressActor
{
    public class DeleteActorMovieCommandValidator : AbstractValidator<DeleteActressActorMovieCommand>
    {
        public DeleteActorMovieCommandValidator()
        {            
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}