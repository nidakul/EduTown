using FluentValidation;

namespace Application.Features.PostCommentTaggedUsers.Commands.Delete;

public class DeletePostCommentTaggedUserCommandValidator : AbstractValidator<DeletePostCommentTaggedUserCommand>
{
    public DeletePostCommentTaggedUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}