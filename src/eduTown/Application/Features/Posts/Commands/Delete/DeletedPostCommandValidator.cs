using FluentValidation;

namespace Application.Features.Posts.Commands.Delete;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}