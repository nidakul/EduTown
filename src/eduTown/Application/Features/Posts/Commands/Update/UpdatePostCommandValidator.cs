using FluentValidation;

namespace Application.Features.Posts.Commands.Update;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.IsCommentable).NotEmpty();
    }
}