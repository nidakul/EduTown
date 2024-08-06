using FluentValidation;

namespace Application.Features.PostComments.Commands.Create;

public class CreatePostCommentCommandValidator : AbstractValidator<CreatePostCommentCommand>
{
    public CreatePostCommentCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
    }
}