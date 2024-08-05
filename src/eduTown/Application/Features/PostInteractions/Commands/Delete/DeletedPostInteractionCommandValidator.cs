using FluentValidation;

namespace Application.Features.PostInteractions.Commands.Delete;

public class DeletePostInteractionCommandValidator : AbstractValidator<DeletePostInteractionCommand>
{
    public DeletePostInteractionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}