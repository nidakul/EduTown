using FluentValidation;

namespace Application.Features.SchoolLessons.Commands.Create;

public class CreateSchoolLessonCommandValidator : AbstractValidator<CreateSchoolLessonCommand>
{
    public CreateSchoolLessonCommandValidator()
    {
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}