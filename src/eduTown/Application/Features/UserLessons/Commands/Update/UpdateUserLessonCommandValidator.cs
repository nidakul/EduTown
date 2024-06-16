using FluentValidation;

namespace Application.Features.UserLessons.Commands.Update;

public class UpdateUserLessonCommandValidator : AbstractValidator<UpdateUserLessonCommand>
{
    public UpdateUserLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}