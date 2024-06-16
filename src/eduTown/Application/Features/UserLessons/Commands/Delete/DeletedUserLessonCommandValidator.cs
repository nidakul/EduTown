using FluentValidation;

namespace Application.Features.UserLessons.Commands.Delete;

public class DeleteUserLessonCommandValidator : AbstractValidator<DeleteUserLessonCommand>
{
    public DeleteUserLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}