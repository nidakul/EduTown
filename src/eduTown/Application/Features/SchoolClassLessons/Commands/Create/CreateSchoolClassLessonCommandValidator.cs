using FluentValidation;

namespace Application.Features.SchoolClassLessons.Commands.Create;

public class CreateSchoolClassLessonCommandValidator : AbstractValidator<CreateSchoolClassLessonCommand>
{
    public CreateSchoolClassLessonCommandValidator()
    {
        RuleFor(c => c.SchoolClassroomId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}