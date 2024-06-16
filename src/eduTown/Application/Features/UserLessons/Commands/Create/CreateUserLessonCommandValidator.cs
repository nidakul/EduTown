using FluentValidation;

namespace Application.Features.UserLessons.Commands.Create;

public class CreateUserLessonCommandValidator : AbstractValidator<CreateUserLessonCommand>
{
    public CreateUserLessonCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}