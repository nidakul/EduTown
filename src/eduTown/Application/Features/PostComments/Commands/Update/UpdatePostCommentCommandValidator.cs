using FluentValidation;

namespace Application.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommandValidator : AbstractValidator<UpdatePostCommentCommand>
{
    public UpdatePostCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
    }
}