using FluentValidation;

namespace Application.Features.PostCommentTaggedUsers.Commands.Update;

public class UpdatePostCommentTaggedUserCommandValidator : AbstractValidator<UpdatePostCommentTaggedUserCommand>
{
    public UpdatePostCommentTaggedUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PostCommentId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}