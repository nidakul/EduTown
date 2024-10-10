using FluentValidation;

namespace Application.Features.PostCommentTaggedUsers.Commands.Create;

public class CreatePostCommentTaggedUserCommandValidator : AbstractValidator<CreatePostCommentTaggedUserCommand>
{
    public CreatePostCommentTaggedUserCommandValidator()
    {
        RuleFor(c => c.PostCommentId).NotEmpty();
        RuleFor(c => c.TaggedUserId).NotEmpty();
    }
}