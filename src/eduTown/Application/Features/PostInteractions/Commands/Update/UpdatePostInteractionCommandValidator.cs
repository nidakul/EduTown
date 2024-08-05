using FluentValidation;

namespace Application.Features.PostInteractions.Commands.Update;

public class UpdatePostInteractionCommandValidator : AbstractValidator<UpdatePostInteractionCommand>
{
    public UpdatePostInteractionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.IsFavorite).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
    }
}