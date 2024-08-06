using FluentValidation;

namespace Application.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandValidator : AbstractValidator<DeletePostCommentCommand>
{
    public DeletePostCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}