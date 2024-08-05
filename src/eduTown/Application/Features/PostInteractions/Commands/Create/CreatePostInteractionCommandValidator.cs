using FluentValidation;

namespace Application.Features.PostInteractions.Commands.Create;

public class CreatePostInteractionCommandValidator : AbstractValidator<CreatePostInteractionCommand>
{
    public CreatePostInteractionCommandValidator()
    {
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.IsFavorite).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
    }
}